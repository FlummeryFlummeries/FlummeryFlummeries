using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class OrderCartItem
    {
        public int OrderCartId { get; set; }

        public int ProductId { get; set; }

        public Flummery Product { get; set; }

        public int Qty { get; set; }
    }
}
