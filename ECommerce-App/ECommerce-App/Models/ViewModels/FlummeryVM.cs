using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
    public class FlummeryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public  decimal Price { get; set; }

        public int Calories { get; set; }

        public decimal Weight { get; set; }

        public string Compliment { get; set; }
    }
}
