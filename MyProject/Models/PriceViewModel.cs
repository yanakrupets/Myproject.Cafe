using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class PriceViewModel
    {
        public Size Size { get; set; }
        public ushort Weight { get; set; }
        public WeightMeasure Measure { get; set; }
        public double Prise { get; set; }
    }
}
