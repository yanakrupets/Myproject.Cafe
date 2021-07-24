using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Repositories
{
    public class DishInOrderRepository : BaseRepository<DishInOrder>, IDishInOrderRepository
    {
        public DishInOrderRepository(CafeDbContext cafeDbContext) : base(cafeDbContext)
        {
        }
    }
}
