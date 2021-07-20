using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Repositories
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        //private IPriceRepository _priceRepository;

        public DishRepository(CafeDbContext cafeDbContext/*, IPriceRepository priceRepository*/) : base(cafeDbContext)
        {
            //_priceRepository = priceRepository;
        }

        //public override List<Dish> GetAll()
        //{
        //    var prices = _priceRepository.GetAll();
        //    var dishes = base.GetAll();
        //    foreach(var price in prices)
        //    {
        //        if (dishes.SingleOrDefault(x => x.Id == price.Dish.Id).Prices != null)
        //        {
        //            dishes.SingleOrDefault(x => x.Id == price.Dish.Id).Prices[0] = price;
        //        }
        //        else
        //        {
        //            foreach(var item in dishes.Where(x => x.Id == price.Dish.Id).ToList())
        //            {
        //                item.Prices = prices.Where(x => x.Dish.Id == item.Id).ToList();
        //            }
        //        }
        //    }

        //    return base.GetAll();
        //}
    }
}
