using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public interface IProduct
    {
        /// <summary>
        /// Read the data from the Cereal csv file
        /// </summary>
        /// <returns>List of all data formatted to Products</returns>
        List<Product> GetProducts();
    }
}
