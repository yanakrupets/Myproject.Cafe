﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Model
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public virtual List<Dish> Dishes { get; set; }
    }
}
