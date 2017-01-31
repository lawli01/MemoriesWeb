﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemoriesWeb.Core.Model;
using MemoriesWeb.Core.Repositories;
using Microsoft.Extensions.Options;
using MemoriesWeb.Photo;

namespace MemoriesWeb.Controllers
{
    public class ManageController : Controller
    {
        private readonly IRepository<Memory> _memoryRepository;
        private readonly IPhotoService _photoService;

        public ManageController(
            IRepository<Memory> memoryRepository,
            IPhotoService photoService)
        {
            _memoryRepository = memoryRepository;
            _photoService = photoService;
        }

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
                await _memoryRepository.AddAsync(memory);
                message = "Memory saved successfully";
                status = true;
            }
            catch(Exception)
            {
                message = "An error occurred when saving Memory";
            }
          
            return Json( new { status = status, message = message });
        }

        [Route("/photos")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult> Photos()
        {
            var photos = await _photoService.GetPhotosFromPhotoService(1);

            return Json(new { result = photos.Select(p => p.images.thumbnail.url) });
        }
    }
}
