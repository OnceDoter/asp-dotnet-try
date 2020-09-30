using System.Collections.Generic;
using AngularWebApi.Data;
using AngularWebApi.Data.Models;
using System.Linq;
using WebApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApi.Controllers.Videos
{
    [Authorize]
    public class VideoService : IVideoService
    {
        private readonly ContentRepository<Video> repo;
        public VideoService(WebApiDbContext data)
            => repo = new ContentRepository<Video>(data);

        public ActionResult Create(Video video)
            => repo.Create(video);

        // TODO: logic on client side
        public ActionResult Update(Video video)
            => repo.Update(video);

        public ActionResult Delete(int id)
            => repo.Delete(id);

        public IEnumerable<Video> GetVideos()
            => repo.GetList();

        public IEnumerable<Video> ByUser(string userId)
            => repo.GetList().Where(v => v.UserId == userId);
    }
}
