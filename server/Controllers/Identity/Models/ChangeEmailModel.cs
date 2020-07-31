using System.ComponentModel.DataAnnotations;

namespace AngularWebApi.Controllers.Identity.Models
{
    public class ChangeEmailModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
