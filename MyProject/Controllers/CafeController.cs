using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.EfStuff.Model;
using MyProject.EfStuff.Repositories;
using MyProject.Models;
using MyProject.Service;
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
        private IDishInOrderRepository _dishInOrderRepository;
        private IPriceRepository _priceRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IBasketRepository _basketRepository;
        private IUserService _userService;
        private IMapper _mapper;

        public CafeController(ICategoryRepository categoryRepository, IDishRepository dishRepository,
            IMapper mapper, IPriceRepository priceRepository, IUserService userService,
            IOrderRepository orderRepository, IUserRepository userRepository,
            IBasketRepository basketRepository, IDishInOrderRepository dishInOrderRepository)
        {
            _categoryRepository = categoryRepository;
            _dishRepository = dishRepository;
            _priceRepository = priceRepository;
            _mapper = mapper;
            _userService = userService;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _basketRepository = basketRepository;
            _dishInOrderRepository = dishInOrderRepository;
        }

        public IActionResult Menu()
        {
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

        public IActionResult AddToBasket(string dishId, string dishSize)
        {
            var id = (long)Convert.ToDouble(dishId);
            var size = Size.NoSize;
            if(dishSize != "undefined")
            {
                size = (Size)Enum.Parse(typeof(Size), dishSize);
            }
            var dish = _dishRepository.Get(id);
            var dishInOrder = new DishInOrder()
            {
                Name = dish.Name,
                ImageUrl = dish.ImageUrl,
                Size = size,
                Weight = dish.Prices.SingleOrDefault(x => x.Size == size).Weight,
                Measure = dish.Prices.SingleOrDefault(x => x.Size == size).Measure,
                Prise = dish.Prices.SingleOrDefault(x => x.Size == size).Prise
            };

            var user = _userService.GetCurrent();
            user.Basket.Dishes.Add(dishInOrder);
            _userRepository.Save(user);
            
            return Json(true);
        }

        [HttpGet]
        public IActionResult Basket()
        {
            var user = _userService.GetCurrent();
            var model = new OrderViewModel()
            {
                DishesInOrder = _mapper.Map<List<DishInOrderViewModel>>(user.Basket.Dishes),
                UserId = user.Id
            };

            if (user.Card != null)
            {
                model.Card = user.Card;
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Basket(OrderViewModel model)
        {
            var order = _mapper.Map<Order>(model);
            order.OrderDate = DateTime.Now;

            double price = 0;
            foreach(var dish in model.DishesInOrder)
            {
                price += dish.Prise;
            }
            order.TotalPrice = price;

            var user = _userService.GetCurrent();
            user.OrderHistory.Add(order);
           
            foreach(var dish in user.Basket.Dishes)
            {
                user.Basket.Dishes.Remove(dish);
            }
            _userRepository.Save(user);

            return RedirectToAction("Menu");
        }

        public IActionResult RemoveDish(string dishId)
        {
            var id = (long)Convert.ToDouble(dishId);
            var user = _userService.GetCurrent();
            var dish = _dishInOrderRepository.Get(id);
            user.Basket.Dishes.Remove(dish);
            _userRepository.Save(user);

            return Json(true);
        }
    }
}
