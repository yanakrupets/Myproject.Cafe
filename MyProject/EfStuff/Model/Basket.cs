using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Model
{
    public class Basket : BaseModel
    {
        public virtual List<DishInOrder> Dishes { get; set; }
        public long ForeignKeyUser { get; set; }
        public virtual User User { get; set; }
    }
}
