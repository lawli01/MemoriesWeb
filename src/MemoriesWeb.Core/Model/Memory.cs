using System;

namespace MemoriesWeb.Core.Model
{
    public class Memory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime UploadDate { get; set; }
        public object Image { get; set; }
        public string UserId { get; set; }
    }
}
