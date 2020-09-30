using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.Videos.Models
{
    public class CreateVideoRequestModel
    {
        [Required]
        public byte[] Data { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        [Required]
        public (int, int) Resolution { get; set; }
    }
}
