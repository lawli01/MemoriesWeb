using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;
using Newtonsoft.Json;

namespace MemoriesWeb.Photo
{
    public class PhotoService : IPhotoService
    {
        public async Task<IEnumerable<InstagramPhoto>> GetPhotosFromPhotoService(int userId)
        {
            string page = $"http://localhost:8081/api/photos/{userId}";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<InstagramPhoto>>(result); ;
            }
        }
    }
}
