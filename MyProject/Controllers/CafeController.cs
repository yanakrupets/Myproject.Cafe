using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.EfStuff.Model;
using MyProject.EfStuff.Repositories;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class CafeController : Controller
    {
        private IReviewRepository _reviewRepository;
        private IMapper _mapper;

        public CafeController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

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
