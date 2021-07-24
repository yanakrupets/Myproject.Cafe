using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff.Model
{
    public class User : BaseModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public Language Language { get; set; }
        public string AvatarUrl { get; set; }
        public string Card { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual List<Order> OrderHistory { get; set; }
    }
}
