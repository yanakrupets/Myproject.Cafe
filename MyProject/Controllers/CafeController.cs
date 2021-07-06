using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class CafeController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult SpecialOffer()
        {
            return View();
        }
    }
}
