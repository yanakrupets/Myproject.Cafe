using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DishViewModel> Dishes { get; set; }
    }
}
