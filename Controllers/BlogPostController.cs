using BlogApplication_Backend.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace BlogApplication_Backend.Controllers
{
    [EnableCors]    
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        Constants constant = new Constants();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = Constants.Firebase_AuthSecrete,
            BasePath = Constants.Firebase_BasePath            
        };

        IFirebaseClient? fclient;

        [HttpPost]
        [Route("BlogPost/CreateNewPost")]
        public async Task<IActionResult> CreateBlogPost([FromBody] BlogPost post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    fclient = new FireSharp.FirebaseClient(config);
                    if (fclient == null)
                    {
                        return StatusCode(500, "Firebase config data loading issue..");
                    }
                    var data = post;
                    PushResponse response = await fclient.PushAsync(constant.PostDocument + "/", data);
                    data.Id = response.Result.name;
                    data.CreatedDate = DateTime.Now;
                    SetResponse setResponse = await fclient.SetAsync(constant.PostDocument + "/" + data.Id, data);
                    if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Ok(constant.PostSuccessMsg);
                    }
                    else
                    {
                        return StatusCode(404, constant.PostErrorMsg);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return StatusCode(404, ModelState);
            }
        }

        [HttpGet]
        [Route("BlogPost/GetAllBlogPosts")]
        public async Task<IActionResult> GetAllBlogPosts()
        {
                try
                {
                    fclient = new FireSharp.FirebaseClient(config);
                    if (fclient == null)
                    {
                        return StatusCode(500, "Firebase config data loading issue..");
                    }
                    FirebaseResponse response = await fclient.GetAsync(constant.PostDocument);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                        var list = new List<BlogPost>();

                        if (data != null)
                        {
                            foreach (var item in data)
                            {
                                list.Add(JsonConvert.DeserializeObject<BlogPost>(((JProperty)item).Value.ToString()));
                            }
                        }
                        return Ok(list);
                    }
                    else
                    {
                        return StatusCode(404, constant.PostErrorMsg);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
        }

        [HttpPost]
        [Route("BlogPost/CreateBlogPostComment")]
        public async Task<IActionResult> CreateBlogPostComment(Comments comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    fclient = new FireSharp.FirebaseClient(config);
                    PushResponse response = await fclient.PushAsync(constant.CommentDocument + "/", comment);
                    comment.CreatedDate = DateTime.Now;
                    comment.Id = response.Result.name;
                    SetResponse setResponse = await fclient.SetAsync(constant.CommentDocument + "/" + comment.Id, comment);
                    if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Ok(constant.CommentSuccessMsg);
                    }
                    else
                    {
                        return StatusCode(404, constant.CommentErrorMsg);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return StatusCode(404, ModelState);
            }
        }

        [HttpGet]
        [Route("BlogPost/GetBlogPostComments")]
        public async Task<IActionResult> GetBlogPostComments()
        {
            try
            {
                fclient = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = await fclient.GetAsync(constant.CommentDocument);
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                var list = new List<Comments>();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        list.Add(JsonConvert.DeserializeObject<Comments>(((JProperty)item).Value.ToString()));
                    }
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
