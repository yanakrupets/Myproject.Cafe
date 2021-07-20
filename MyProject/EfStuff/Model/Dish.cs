using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Model
{
    public class Dish : BaseModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Price> Prices { get; set; }
    }
}
