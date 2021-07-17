using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Localization;

namespace MyProject.Models
{
    public class UserFormViewModel
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "From 3 to 20 symbols")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "From 3 to 20 symbols")]
        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        [RegularExpression(@"(\d{4}([ ]|)\d{4}([ ]|)\d{4}([ ]|)\d{4})", ErrorMessage = "Wrong card number")]
        public string Card { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Wrong Email")]
        public string Email { get; set; }
    }
}
