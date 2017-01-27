using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemoriesWeb.Core.Model;
using MemoriesWeb.Core.Repositories;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoriesWeb.Controllers
{
    public class ManageController : Controller
    {
        private readonly IMemoryRepository _memoryRepository;
        private IOptions<MySettings> _config;

        public ManageController(IMemoryRepository memoryRepository, IOptions<MySettings> config)
        {
            _config = config;
            _memoryRepository = memoryRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return RedirectToAction("Manage", "Demo");
        }

        [HttpPost]
        public async Task<JsonResult> SaveContactData(Memory memory)
        {
            bool status = false;
            var message = "";
            try
            {
                await _memoryRepository.AddMemory(memory, _config.Value.SqlConnectionString);
                message = "Memory saved successfully";
                status = true;
            }
            catch(Exception)
            {
                message = "An error occurred when saving Memory";
            }
          
            return Json( new { status = status, message = message });
        }
    }
}
