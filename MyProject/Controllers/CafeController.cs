using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.EfStuff.Model;
using MyProject.EfStuff.Repositories;
using MyProject.Models;
using MyProject.Presentation;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

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
        private IMenuService _menuService;
        private ICafePresentation _cafePresentation;
        private IMapper _mapper;

        public CafeController(ICategoryRepository categoryRepository, IDishRepository dishRepository,
            IMapper mapper, IPriceRepository priceRepository, IUserService userService,
            IOrderRepository orderRepository, IUserRepository userRepository,
            IBasketRepository basketRepository, IDishInOrderRepository dishInOrderRepository,
            IMenuService menuService, ICafePresentation cafePresentation)
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
            _menuService = menuService;
            _cafePresentation = cafePresentation;
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
            _cafePresentation.AddToBasket(dishId, dishSize);

            return Json(true);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IActionResult Basket(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Basket");
            }

            var dihesIds = JsonSerializer.Deserialize<List<long>>(model.DishesIdsJson);

            var order = _mapper.Map<Order>(model);
            var dishesInOrder = new List<DishInOrder>();
            for(var i = 0; i < dihesIds.Count; i++)
            {
                dishesInOrder.Add(_dishInOrderRepository.Get(dihesIds[i]));
            }
            order.DishesInOrder = dishesInOrder;
            order.OrderDate = DateTime.Now;

            double price = 0;
            foreach(var dish in order.DishesInOrder)
            {
                price += dish.Prise;
            }
            order.TotalPrice = price;

            var user = _userService.GetCurrent();
            user.OrderHistory.Add(order);

            var count = user.Basket.Dishes.Count;
            var j = 0;
            for (var i = count - 1; j < count; i--, j++)
            {
                user.Basket.Dishes.Remove(user.Basket.Dishes[i]);
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
