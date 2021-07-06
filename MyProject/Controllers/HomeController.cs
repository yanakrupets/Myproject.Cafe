using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Models;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPathHelper _pathHelper;

        public HomeController(ILogger<HomeController> logger, IPathHelper pathHelper)
        {
            _logger = logger;
            _pathHelper = pathHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ImageForCarousel()
        {
            var carouselFolderPath = _pathHelper.GetPathToCarouselFolder();
            var filesPath = Directory.GetFiles(carouselFolderPath);
            var img = filesPath
                .Where(filePath => Path.GetExtension(filePath) == ".jpg")
                .ToList();

            for(var i = 0; i < img.Count; i++)
            {
                var startIndex = img[i].IndexOf("\\images\\carousel\\");
                img[i] = img[i].Remove(0,startIndex).Replace("\\", "/");
            }

            return Json(img);
        }
    }
}
