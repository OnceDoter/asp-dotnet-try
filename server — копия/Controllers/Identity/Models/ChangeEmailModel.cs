using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers.Identity.Models
{
    public class ChangeEmailModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
