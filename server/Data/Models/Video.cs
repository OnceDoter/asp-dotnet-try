using System.ComponentModel.DataAnnotations;
using static AngularWebApi.Data.Validation.Video;

namespace AngularWebApi.Data.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public string VideoUrl { get; set; }
        public string VideoLocPath { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
