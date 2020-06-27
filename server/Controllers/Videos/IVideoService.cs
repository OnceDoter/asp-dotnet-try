using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Controllers.Videos.Models;

namespace WebApplication1.Controllers.Videos
{
    public interface IVideoService
    {
        public Task<int> Create(string videoUrl, string description, string userId);

        public Task<bool> Update(int id, string description, string userId);

        public Task<bool> Delete(int id, string userId);

        public Task<IEnumerable<VideoListingServiceModel>> ByUser(string userId);

        public Task<VideoDetailsServiceModel> Details(int id);
    }
}
