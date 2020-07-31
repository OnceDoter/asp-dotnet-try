using System.ComponentModel.DataAnnotations;

namespace AngularWebApi.Controllers.Identity.Models
{
    public class ChangeUserNameModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
