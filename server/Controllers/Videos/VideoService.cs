﻿using System.Collections.Generic;
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
        private readonly ContentRepository<Video> _repo;
        public VideoService(WebApiDbContext data)
            => _repo = new ContentRepository<Video>(data);

        public ActionResult Create(Video video)
            => _repo.Create(video);

        // TODO: logic on client side
        public ActionResult Update(Video video)
            => _repo.Update(video);

        public ActionResult Delete(int id)
            => _repo.Delete(id);

        public IEnumerable<Video> GetVideos()
            => _repo.GetList();

        public IEnumerable<Video> ByUser(string userId)
            => _repo.GetList().Where(v => v.UserId == userId);
    }
}
