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
        private ICategoryRepository _categoryRepository;
        private IDishRepository _dishRepository;
        private IPriceRepository _priceRepository;
        private IMapper _mapper;

        public CafeController(ICategoryRepository categoryRepository, IDishRepository dishRepository,
            IMapper mapper, IPriceRepository priceRepository)
        {
            _categoryRepository = categoryRepository;
            _dishRepository = dishRepository;
            _priceRepository = priceRepository;
            _mapper = mapper;
        }

        public IActionResult Menu()
        {
            var prices = _priceRepository.GetAll();
            var dishes = _dishRepository.GetAll();
            var categories = _categoryRepository.GetAll();
            var modelCategories = _mapper.Map<List<CategoryViewModel>>(categories);

            var model = new CategoriesViewModel()
            {
                Categories = modelCategories
            };
            return View(model);
        }

        public IActionResult SpecialOffer()
        {
            return View();
        }
    }
}
