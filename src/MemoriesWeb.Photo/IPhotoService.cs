using System.Collections.Generic;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;

namespace MemoriesWeb.Photo
{
    public interface IPhotoService
    {
        Task<IEnumerable<InstagramPhoto>> GetPhotosFromPhotoService(int userid);
    }
}