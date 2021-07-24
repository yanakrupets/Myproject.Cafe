using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class DishInOrderViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Size Size { get; set; }
        public ushort Weight { get; set; }
        public WeightMeasure Measure { get; set; }
        public double Prise { get; set; }
    }
}
