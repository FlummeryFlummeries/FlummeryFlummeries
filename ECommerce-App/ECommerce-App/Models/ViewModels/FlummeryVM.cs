using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
    public class FlummeryVM : ProductVM
    {
        override public int Id { get; set; }

        override public string Name { get; set; }

        override public string Manufacturer { get; set; }

        override public  decimal Price { get; set; }

        public int Calories { get; set; }

        public decimal Weight { get; set; }

        public string Compliment { get; set; }
    }
}
