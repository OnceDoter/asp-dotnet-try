using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Controllers.Videos.Models;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers.Videos
{
    public class VideoService : IVideoService
    {
        private readonly WebDbContext data;

        public VideoService(WebDbContext data) => this.data = data;

        public async Task<int> Create(string videoUrl, string description, string userId)
        {
            var video = new Video()
            {
                VideoUrl = videoUrl,
                Description = description,
                UserId = userId
            };

            data.Add(video);

            await data.SaveChangesAsync();

            return video.Id;
        }

        public async Task<bool> Update(int id, string description, string userId)
        {
            var cat = await GetByIdAndByUserId(id, userId);

            if (cat == null)
            {
                return false;
            }

            cat.Description = description;

            await data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var cat = await GetByIdAndByUserId(id, userId); 
            if (cat == null)return false; 
            data.Videos.Remove(cat);
            await data.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<VideoListingServiceModel>> ByUser(string userId)
            => await data
                .Videos 
                .Where(c => c.UserId == userId)
                .Select(c => new VideoListingServiceModel
                {
                    Id = c.Id,
                    VideoUrl = c.VideoUrl
                })
                .ToListAsync();

        public async Task<VideoDetailsServiceModel> Details(int id)
            => await data
                .Videos
                .Where(c => c.Id == id)
                .Select(c => new VideoDetailsServiceModel
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    VideoUrl = c.VideoUrl,
                    Description = c.Description,
                    UserName = c.User.UserName
                })
                .FirstOrDefaultAsync();

        private async Task<Video> GetByIdAndByUserId(int id, string userId)
            => await data
                .Videos
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
