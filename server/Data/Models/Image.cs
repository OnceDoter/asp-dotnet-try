using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Models
{
    public class Image : IPreserve
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [NotMapped]
        public byte[] Data { get; set; }
        public string Description { get; set; }
        public (int, int) Resolution { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Path { get; set; }
        public User User { get; set; }
    }
}
