using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;

namespace WebApi.Data
{
    public sealed class WebApiDbContext : IdentityDbContext<User>
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Image> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Video>()
                .HasOne(c => c.User)
                .WithMany(u => u.Videos)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Audio>()
                .HasOne(c => c.User)
                .WithMany(u => u.Audios)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Image>()
                .HasOne(c => c.User)
                .WithMany(u => u.Pictures)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
