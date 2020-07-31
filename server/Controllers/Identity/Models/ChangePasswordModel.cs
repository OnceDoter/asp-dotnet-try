using System.ComponentModel.DataAnnotations;

namespace AngularWebApi.Controllers.Identity.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
