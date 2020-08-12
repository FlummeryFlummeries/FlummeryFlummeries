using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
    abstract public class ProductVM
    {
        abstract public int Id { get; set; }

        abstract public string Name { get; set; }

        abstract public string Manufacturer { get; set; }

        abstract public decimal Price { get; set; }
    }
}
