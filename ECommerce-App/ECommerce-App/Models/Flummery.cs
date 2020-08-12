using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class Flummery : Product
    {
        public int Id { get; set; }

        public override string Name { get; set; }

        public override string Manufacturer { get; set; }

        public int Calories { get; set; }

        public decimal Weight { get; set; }

        public string Compliment { get; set; }
    }
}
