namespace WebApplication1.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Models.Users;

    public class WebDbContext : IdentityDbContext<User>
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }
    }
}
