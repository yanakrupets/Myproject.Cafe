using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Model
{
    public class Price : BaseModel
    {
        public Size Size { get; set; }
        public ushort Weight { get; set; }
        public WeightMeasure Measure { get; set; }
        public double Prise { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
