using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers.Identity.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
