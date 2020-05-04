namespace WebApplication1.Controllers.Identity
{
    using System.ComponentModel.DataAnnotations;
    public class ChangeUserNameModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
