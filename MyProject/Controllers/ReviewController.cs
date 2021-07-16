using AutoMapper;
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
    public class ReviewController : Controller
    {
        private IMapper _mapper;
        private IReviewRepository _reviewRepository;

        public ReviewController(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public IActionResult Reviews()
        {
            var model = new ReviewViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Reviews(ReviewViewModel viewModel)
        {
            viewModel.Date = DateTime.Now;
            var model = _mapper.Map<Review>(viewModel);
            _reviewRepository.Save(model);
            return RedirectToAction("Reviews");
        }
    }
}
