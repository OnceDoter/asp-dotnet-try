using System.Collections.Generic;
using System.Threading.Tasks;
using AngularWebApi.Data;
using AngularWebApi.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using WebApi.Controllers.Videos.Models;
using WebApi.Data;

namespace AngularWebApi.Controllers.Videos
{
    public class VideoService : IVideoService
    {
        private const string path = "../videos/";
        private readonly ContentRepository<Video> repo;
        public VideoService(WebApiDbContext data)
            => repo = new ContentRepository<Video>(data);

        public async Task Create(CreateVideoRequestModel model)
        {
            var video = new Video()
            {
                Data = model.Data,
                Description = model.Description,
                Duration = model.Duration,
                Resolution = model.Resolution
            };
            await repo.Create(video);
            await repo.SaveAsync();
        }

        public async Task<bool> Update(int id, string description, string userId)
        {
            var video = await GetByIdAndByUserId(id, userId);
            if (video == null)
            {
                return false;
            }
            video.Description = description;
            await data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var video = await GetByIdAndByUserId(id, userId); 
            if (video == null) return false; 
            data.Videos.Remove(video);
            await data.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<VideoListingServiceModel>> ByUser(string userId)
            => await data
                .Videos 
                .Where(c => c.UserId == userId)
                .Select(c => new VideoListingServiceModel
                {
                    Id = c.Id
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
                    Description = c.Description,
                    UserName = c.User.UserName
                })
                .FirstOrDefaultAsync();

        private async Task<Video> GetByIdAndByUserId(int id, string userId)
            => await data
                .Videos
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();

        public async Task<bool> Upload(UploadVideoRequestModel model)
        {
            var video = await GetByIdAndByUserId(model.Id, model.UserId);
            if (video == null) return false;
            var vlp = Guid.NewGuid().ToString();
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory(path + vlp);
                using Stream stream = new FileStream(path + vlp + "/" + vlp + ".avi", FileMode.OpenOrCreate);
                stream.Write(model.Content, 0, model.Content.Length);
                await data.SaveChangesAsync();
                return true;
            }
            catch { return false; }           
        }
    }
}
