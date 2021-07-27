using NUnit.Framework;
using MyProject.Presentation;
using MyProject.EfStuff.Repositories;
using MyProject.Service;
using Moq;
using MyProject.EfStuff.Model;
using System.Collections.Generic;
using System;

namespace MyProject.Test.Presentation
{
    public class CafePresentationTest
    {
        private CafePresentation _cafePresentation;
        private Mock<IDishRepository> _mockDishRepository;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IMenuService> _mockMenuService;
        private Mock<IUserService> _mockUserService;

        [SetUp]
        public void SetUp()
        {
            _mockDishRepository = new Mock<IDishRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMenuService = new Mock<IMenuService>();
            _mockUserService = new Mock<IUserService>();

            _cafePresentation = new CafePresentation(
                _mockDishRepository.Object,
                _mockMenuService.Object,
                _mockUserService.Object,
                _mockUserRepository.Object);
        }

        //[Test]
        //[TestCase("9", "undefined")]
        //public void AddToBasket_UndefinedSize(string id, string size)
        //{
        //    var dishId = id;
        //    var dishSize = size;

        //    var category = new Category()
        //    {
        //        Name = "FirstCategory"
        //    };
        //    var price1 = new Price()
        //    {
        //        Size = Size.NoSize,
        //        Weight = 200,
        //        Measure = WeightMeasure.gram,
        //        Prise = 4.5
        //    };
        //    var price2 = new Price()
        //    {
        //        Size = Size.M,
        //        Weight = 300,
        //        Measure = WeightMeasure.mL,
        //        Prise = 5
        //    };
        //    var prices = new List<Price>() { price1, price2 };
        //    var dish = new Dish()
        //    {
        //        Name = "FirstDish",
        //        ImageUrl = "ImgUrl",
        //        Category = category,
        //        Prices = prices
        //    };

        //    var dishIdGet = (long)Convert.ToDouble(dishId);
        //    _mockDishRepository.Setup(x => x.Get(dishIdGet)).Returns(dish);

        //    var dishSizeMenu = Size.NoSize;
        //    var dish2 = new DishInOrder()
        //    {
        //        Name = "FirstDish",
        //        ImageUrl = "ImgUrl",
        //        Size = dishSizeMenu,
        //        Weight = 300,
        //        Measure = WeightMeasure.mL,
        //        Prise = 5
        //    };
        //    _mockMenuService.Setup(x => x.CreateDishInOrder(dish, dishSizeMenu)).Returns(dish2);


        //    _cafePresentation.AddToBasket(dishId, dishSize);
        //}
    }
}