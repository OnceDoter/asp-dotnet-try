
namespace WebApplication1.Controllers.Identity
{
    using System.ComponentModel.DataAnnotations;
    public class ChangeEmailModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
