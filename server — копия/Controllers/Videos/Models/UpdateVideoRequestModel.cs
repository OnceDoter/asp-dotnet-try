using System.ComponentModel.DataAnnotations;
using static WebApplication1.Data.Validation.Video;

namespace WebApplication1.Controllers.Videos.Models
{
    public class UpdateVideoRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
