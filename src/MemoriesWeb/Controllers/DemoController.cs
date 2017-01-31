using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoriesWeb.Core.Model;
using Microsoft.AspNetCore.Mvc;
using MemoriesWeb.Core.Repositories;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoriesWeb.Controllers
{
    public class DemoController : Controller
    {
        private readonly IRepository<Memory> _memoryRepository;

        public DemoController(IRepository<Memory> memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [Route("Demo/Memories")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult> Memories()
        {
            var memories = await _memoryRepository.FindAllAsync();

            return Json(new { result = memories });
        }
    }
}
