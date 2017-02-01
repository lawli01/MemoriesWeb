using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MemoriesWeb.Core.Common;
using MemoriesWeb.Core.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MemoriesWeb.Photo
{
    public class PhotoService : IPhotoService
    {
        private readonly string _photoServiceUrl;

        public PhotoService(IOptions<MySettings> config)
        {
            _photoServiceUrl = config.Value.PhotoServiceUrl;
        }

        public async Task<IEnumerable<InstagramPhoto>> GetPhotosFromPhotoService(int userId)
        {
            string page = $"{_photoServiceUrl}/{userId}";

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
