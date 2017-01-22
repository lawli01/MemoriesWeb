using MemoriesWeb.Core.Model;
using MemoriesWeb.Core.Repositories;
using MemoriesWeb.Messaging;
using MemoriesWeb.Photo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

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

            var photos = _photoService.GetPhotosFromPhotoService();

            ViewData["Images"] = photos.Result.Select(p => p.images.thumbnail.url);
            //Receive rec = new Receive();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            //Send send = new Send();
            //send.SendMessage();

            //var mem = new Memory()
            //{
            //    Name = "MyFirstMemory",
            //    Rating = 5,
            //    UploadDate = DateTime.UtcNow,
            //    UserId = Guid.NewGuid().ToString()
            //};

            //_memoryRepository.AddMemory(mem, _config.Value.SqlConnectionString);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
