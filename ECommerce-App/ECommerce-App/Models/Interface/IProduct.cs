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

        /// <summary>
        /// Sort the products in the list by the given sort type
        /// </summary>
        /// <returns>Sorted list</returns>
        List<Product> SortProducts(string type);


        /// <summary>
        /// Read the data from the Cereal csv file
        /// </summary>
        /// <returns>Details of specific item</returns>
        Product GetProduct(string search);
    }
}
