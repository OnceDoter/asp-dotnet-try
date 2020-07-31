using WebApplication1.Data;
using WebApplication1.Data.Models;

namespace WebApplication1.Infrastructure
{
    public static class DbContextExtensions
    {
        public static VideoContext Add(this VideoContext context, Video video)
        {
            context.Add(video);
            return context;
        }
    }
}
