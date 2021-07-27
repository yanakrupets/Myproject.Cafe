using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Model
{
    public class Order : BaseModel
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool isOrderPaid { get; set; }
        public double TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Delivery Delivery { get; set; }
        public string Card { get; set; }
        public virtual User User { get; set; }
        public virtual List<DishInOrder> DishesInOrder { get; set; }
    }
}
