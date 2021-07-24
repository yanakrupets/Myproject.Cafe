using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class OrderViewModel
    {
        public List<DishInOrderViewModel> DishesInOrder { get; set; }
        public long UserId { get; set; }
        public string Card { get; set; }
        public string CustomerName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Delivery Delivery { get; set; }
    }
}
