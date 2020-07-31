﻿using System.ComponentModel.DataAnnotations;
using static AngularWebApi.Data.Validation.Video;

namespace AngularWebApi.Controllers.Videos.Models
{
    public class VideoDetailsServiceModel : VideoListingServiceModel
    {

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
