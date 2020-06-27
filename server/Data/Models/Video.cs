using System.ComponentModel.DataAnnotations;
using static WebApplication1.Data.Validation.Video;

namespace WebApplication1.Data.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
