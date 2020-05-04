namespace WebApplication1.Controllers.Identity
{
    using System.ComponentModel.DataAnnotations;
    public class ChangePasswordModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
