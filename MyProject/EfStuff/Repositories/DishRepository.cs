﻿using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Repositories
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        public DishRepository(CafeDbContext cafeDbContext) : base(cafeDbContext)
        {
        }
    }
}
