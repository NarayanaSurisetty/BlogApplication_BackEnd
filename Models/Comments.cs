using System.ComponentModel.DataAnnotations;

namespace BlogApplication_Backend.Models
{
    public class Comments
    {
        public string? Id { get; set; }
        [Required]
        public string? PostId { get; set; }
        [Required]
        public string? UserUID { get; set; }
        public string? UserName { get; set; }
        public string? CommentDescription { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
