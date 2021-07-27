using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class DishToAddViewModel
    {
        public string Name { get; set; }
        public IFormFile ImgUrl { get; set; }
        public string Category { get; set; }
        public List<SelectListItem> CategoryOptions { get; set; }
        public List<SelectListItem> MeasureOptions { get; set; }
        public DishToAddViewModel()
        {
        }
        public DishToAddViewModel(List<CategoryViewModel> categories)
        {
            CategoryOptions = new List<SelectListItem>();
            CategoryOptions.Add(new SelectListItem()
            {
                Text = "Select",
                Value = "-1",
                Disabled = true,
                Selected = true
            });

            foreach (var option in categories)
            {
                var selectListItem = new SelectListItem()
                {
                    Text = option.Name,
                    Value = option.Name
                };

                CategoryOptions.Add(selectListItem);
            }

            MeasureOptions = new List<SelectListItem>();
            MeasureOptions.Add(new SelectListItem()
            {
                Text = "Select",
                Value = "-1",
                Disabled = true,
                Selected = true
            });

            foreach (var option in Enum.GetValues(typeof(WeightMeasure)))
            {
                var selectListItem = new SelectListItem()
                {
                    Text = option.ToString(),
                    Value = option.ToString()
                };

                MeasureOptions.Add(selectListItem);
            }

        }
        public WeightMeasure Measure { get; set; }
        public List<Size> Sizes { get; set; }
        public List<double> Weights { get; set; }
        public List<double> Prices { get; set; }
    }
}
