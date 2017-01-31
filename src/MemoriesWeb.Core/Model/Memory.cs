using System;
using System.ComponentModel.DataAnnotations;

namespace MemoriesWeb.Core.Model
{
    public class Memory : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime UploadDate { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
