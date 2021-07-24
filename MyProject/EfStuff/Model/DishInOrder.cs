using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Model
{
    public class DishInOrder : BaseModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Size Size { get; set; }
        public ushort Weight { get; set; }
        public WeightMeasure Measure { get; set; }
        public double Prise { get; set; }
        public virtual List<Basket> Baskets { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
