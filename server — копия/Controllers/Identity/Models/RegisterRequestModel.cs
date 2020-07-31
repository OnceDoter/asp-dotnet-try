using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers.Identity.Models
{
    public class RegisterRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
