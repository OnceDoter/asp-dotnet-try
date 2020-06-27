using System.ComponentModel.DataAnnotations;
using static WebApplication1.Data.Validation.Video;

namespace WebApplication1.Controllers.Videos.Models
{
    public class VideoDetailsServiceModel : VideoListingServiceModel
    {

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
