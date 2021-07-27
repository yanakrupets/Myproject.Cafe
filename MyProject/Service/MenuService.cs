using Microsoft.AspNetCore.Hosting;
using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Service
{
    public class MenuService : IMenuService
    {
        private IWebHostEnvironment _hostEnvironment;

        public MenuService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public DishInOrder CreateDishInOrder(Dish dish, Size size)
        {
            var dishInOrder = new DishInOrder()
            {
                Name = dish.Name,
                ImageUrl = dish.ImageUrl,
                Size = size,
                Weight = dish.Prices.SingleOrDefault(x => x.Size == size).Weight,
                Measure = dish.Prices.SingleOrDefault(x => x.Size == size).Measure,
                Prise = dish.Prices.SingleOrDefault(x => x.Size == size).Prise
            };

            return dishInOrder;
        }
    }
}
