using AngularWebApi.Data;
using AngularWebApi.Data.Models;

namespace AngularWebApi.Infrastructure
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
