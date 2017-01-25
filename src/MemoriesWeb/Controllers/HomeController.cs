using MemoriesWeb.Core.Model;
using MemoriesWeb.Core.Repositories;
using MemoriesWeb.Messaging;
using MemoriesWeb.Photo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesWeb.Controllers
{
    public class HomeController : Controller
    {
        private IOptions<MySettings> _config;
        private readonly IMemoryRepository _memoryRepository;
        private readonly IPhotoService _photoService;


        public HomeController(IOptions<MySettings> config, IMemoryRepository memoryRepository, IPhotoService photoService)
        {
            _config = config;
            _memoryRepository = memoryRepository;
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }

        [Route("photos")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult> Photos()
        {
            var photos = await _photoService.GetPhotosFromPhotoService(1);

            return Json(new { result = photos.Select(p => p.images.thumbnail.url) });
        }
    }
}
