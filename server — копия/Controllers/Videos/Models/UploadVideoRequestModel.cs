using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers.Videos.Models
{
    public class UploadVideoRequestModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Content { get; set; }
    }
}
