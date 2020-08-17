using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    abstract public class Product
    {
        abstract public int Id { get; set; }

        abstract public string Name { get; set; }

        abstract public string Manufacturer { get; set; }

        abstract public decimal Price { get; set; }

        abstract public string ImageUrl { get; set; }
    }
}
