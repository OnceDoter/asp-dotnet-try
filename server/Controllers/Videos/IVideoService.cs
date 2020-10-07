using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;

namespace WebApi.Controllers.Videos
{
    public interface IVideoService
    {
        public ActionResult Create(Video video);

        public ActionResult Update(Video video);

        public ActionResult Delete(int id);
        public IEnumerable<Video> GetVideos();
        public IEnumerable<Video> ByUser(string userId);

    }
}
