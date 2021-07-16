using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class ReviewViewModel
    {
        public long Owner { get; set; }
        public string ReviewMessage { get; set; }
        public DateTime Date { get; set; }
    }
}
