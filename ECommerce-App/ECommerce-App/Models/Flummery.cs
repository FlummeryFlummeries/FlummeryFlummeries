using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class Flummery : Product
    {
        public override int Id { get; set; }

        public override string Name { get; set; }

        public override string Manufacturer { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public override decimal Price { get; set; }

        public override string ImageUrl { get; set; }

        public int Calories { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Weight { get; set; }

        public string Compliment { get; set; }
    }
}
