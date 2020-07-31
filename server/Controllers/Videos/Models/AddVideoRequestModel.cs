using System.ComponentModel.DataAnnotations;
using static AngularWebApi.Data.Validation.Video;

namespace AngularWebApi.Controllers.Videos.Models
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
