using System.ComponentModel.DataAnnotations;
using static WebApplication1.Data.Validation.Video;

namespace WebApplication1.Controllers.Videos.Models
{
    public class AddVideoRequestModel
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
