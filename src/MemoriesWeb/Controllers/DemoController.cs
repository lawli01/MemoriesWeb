using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoriesWeb.Controllers
{
    public class DemoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
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
            return View();
        }
    }
}
