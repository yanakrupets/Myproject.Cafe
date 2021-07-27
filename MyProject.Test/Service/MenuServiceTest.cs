using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MyProject.Service;
using Moq;
using Microsoft.AspNetCore.Hosting;

namespace MyProject.Test.Service
{
    class MenuServiceTest
    {
        private MenuService _menuService;
        private Mock<IWebHostEnvironment> _mockWebHostEnvironment;

        [SetUp]
        public void Setup()
        {
            _mockWebHostEnvironment = new Mock<IWebHostEnvironment>();

            _menuService = new MenuService(
                _mockWebHostEnvironment.Object);
        }

        [Test]
        [TestCase(Size.M)]
        public void CreateDishInOrder_Test(Size size)
        {
            var category = new Category()
            {
                Name = "FirstCategory"
            };
            var price1 = new Price()
            {
                Size = Size.NoSize,
                Weight = 200,
                Measure = WeightMeasure.gram,
                Prise = 4.5
            };
            var price2 = new Price()
            {
                Size = Size.M,
                Weight = 300,
                Measure = WeightMeasure.mL,
                Prise = 5
            };
            var prices = new List<Price>() { price1, price2 };
            var dish1 = new Dish()
            {
                Name = "FirstDish",
                ImageUrl = "ImgUrl",
                Category = category,
                Prices = prices
            };

            var dish2 = new DishInOrder()
            {
                Name = "FirstDish",
                ImageUrl = "ImgUrl",
                Size = size,
                Weight = 300,
                Measure = WeightMeasure.mL,
                Prise = 5
            };

            var dishInOrder = _menuService.CreateDishInOrder(dish1, size);

            Assert.AreEqual(dish2.Name, dishInOrder.Name);
            Assert.AreEqual(dish2.ImageUrl, dishInOrder.ImageUrl);
            Assert.AreEqual(dish2.Size, dishInOrder.Size);
            Assert.AreEqual(dish2.Weight, dishInOrder.Weight);
            Assert.AreEqual(dish2.Measure, dishInOrder.Measure);
            Assert.AreEqual(dish2.Prise, dishInOrder.Prise);
        }
    }
}
