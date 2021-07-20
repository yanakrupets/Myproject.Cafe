using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class DishViewModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        //public virtual Category Category { get; set; }
        public List<PriceViewModel> Prices { get; set; }
    }
}
