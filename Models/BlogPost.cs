using System.ComponentModel.DataAnnotations;

namespace BlogApplication_Backend.Models
{
    public class BlogPost
    {
        public string? Id { get; set; }
        [Required]
        public string? UserUID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class UpdatePost
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
