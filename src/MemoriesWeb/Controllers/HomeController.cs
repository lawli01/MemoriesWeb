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
        private readonly IRepository<Memory> _memoryRepository;

        public HomeController(IOptions<MySettings> config, IRepository<Memory> memoryRepository, IPhotoService photoService)
        {
            _config = config;
            _memoryRepository = memoryRepository;
            _memoryRepository.AddAsync(null);
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }

       
    }
}
