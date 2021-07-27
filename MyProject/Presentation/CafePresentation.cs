using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.EfStuff.Model;
using MyProject.EfStuff.Repositories;
using MyProject.Service;

namespace MyProject.Presentation
{
    public class CafePresentation : ICafePresentation
    {
        private IDishRepository _dishRepository;
        private IUserRepository _userRepository;
        private IMenuService _menuService;
        private IUserService _userService;

        public CafePresentation(IDishRepository dishRepository, IMenuService menuService,
            IUserService userService, IUserRepository userRepository)
        {
            _dishRepository = dishRepository;
            _menuService = menuService;
            _userService = userService;
            _userRepository = userRepository;
        }

        public void AddToBasket(string dishId, string dishSize)
        {
            var id = (long)Convert.ToDouble(dishId);
            var size = Size.NoSize;
            if (dishSize != "undefined")
            {
                size = (Size)Enum.Parse(typeof(Size), dishSize);
            }
            var dish = _dishRepository.Get(id);
            var dishInOrder = _menuService.CreateDishInOrder(dish, size);

            var user = _userService.GetCurrent();
            user.Basket.Dishes.Add(dishInOrder);
            _userRepository.Save(user);
        }
    }
}
