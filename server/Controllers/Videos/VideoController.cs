using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Videos.Models;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controllers.Videos
{
    [Authorize]
    public class VideoController : ApiController
    {
        private readonly IVideoService videoService;

        public VideoController(IVideoService catService) => this.videoService = catService;

        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<VideoListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.videoService.ByUser(userId);
        }

        [HttpGet]
        [Route(nameof(Details))]
        public async Task<ActionResult<VideoDetailsServiceModel>> Details(int id)
            => await this.videoService.Details(id);

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(AddVideoRequestModel model)
        {
            var userId = this.User.GetId();

            var id = await this.videoService.Create(
                model.ImageUrl,
                model.Description,
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update(UpdateVideoRequestModel model)
        {
            var userId = this.User.GetId();

            var updated = await this.videoService.Update(
                model.Id,
                model.Description,
                userId);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.User.GetId();

            var deleted = await this.videoService.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
