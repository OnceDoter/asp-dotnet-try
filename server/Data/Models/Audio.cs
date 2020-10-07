using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Models
{
    public class Audio : IPreserve
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [NotMapped]
        public byte[] Data { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public string Path { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
