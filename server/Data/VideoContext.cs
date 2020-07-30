using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class VideoContext : IdentityDbContext<User>
    {
        public VideoContext(DbContextOptions<VideoContext> options) : base(options) { }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Video>()
                .HasOne(c => c.User)
                .WithMany(u => u.Videos)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
