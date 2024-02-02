using FireSharp.Config;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Diagnostics.Metrics;

namespace BlogApplication_Backend
{
    public class Constants
    {

        public static string apiKey = "AIzaSyAdlFNHk_GvAQgoG-ve8DTVSvlbPdNva6Q";
        public static string authDomain = "blog-application-10734984.firebaseapp.com";
        public static string databaseURL = "https://blog-application-10734984-default-rtdb.firebaseio.com";
        public static string projectId = "blog-application-10734984";
        public static string storageBucket = "blog-application-10734984.appspot.com";
        public static string messagingSenderId = "516506896177";
        public static string appId = "1:516506896177:web:a24d4965aec0ab2adc5210";
        public static string measurementId = "G-MZJC4NK4G4";

        public static string Firebase_AuthSecrete = "6xDcJINOfOgPyZ2luYCoZxQ7PIAWwYpVsyvn6z6e";
        public static string Firebase_BasePath = "https://blog-application-10734984-default-rtdb.firebaseio.com";

        public string PostDocument = "BlogPosts";
        public string CommentDocument = "BlogPostComments";

        public string PostSuccessMsg = "New post created successfully!";
        public string PostErrorMsg = "New post failed to created!";
        public string CommentSuccessMsg = "New comment created successfully!";
        public string CommentErrorMsg = "New comment failed to created!";
    }
}
