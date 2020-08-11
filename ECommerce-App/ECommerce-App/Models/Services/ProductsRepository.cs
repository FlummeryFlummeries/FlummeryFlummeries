using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class ProductsRepository : IProduct
    {
        /// <summary>
        /// Read the data from the Cereal csv file
        /// </summary>
        /// <returns>List of all data formatted to Products</returns>
        public List<Product> GetProducts()
        {
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
            string[] myFile = File.ReadAllLines(newPath);
            myFile = myFile[1..];
            List<Product> list = new List<Product>();
            foreach (var item in myFile)
            {
                string[] split = item.Split(",");
                list.Add(new Product()
                {
                    Name = split[0],
                    Manufacturer = GetManufacturer(split[1]),
                    Type = split[2],
                    Calories = int.Parse(split[3]),
                    Protein = int.Parse(split[4]),
                    Fat = int.Parse(split[5]),
                    Sodium = int.Parse(split[6]),
                    Fiber = decimal.Parse(split[7]),
                    Carbs = decimal.Parse(split[8]),
                    Sugar = int.Parse(split[9]),
                    Potassium = int.Parse(split[10]),
                    Vitamins = int.Parse(split[11]),
                    Shelf = int.Parse(split[12]),
                    Weight = decimal.Parse(split[13]),
                    Cups = decimal.Parse(split[14]),
                    Rating = decimal.Parse(split[15])
                });
            }
            return list;
        }

        public List<Product> SortProducts(string type)
        {
            List<Product> list = GetProducts();
            switch (type)
            {
                case "alphabetical":
                    list.Sort((x, y) => string.Compare(x.Name, y.Name));
                    break;
                case "alphabeticalRev":
                    list.Sort((x, y) => string.Compare(x.Name, y.Name));
                    list.Reverse();
                    break;
                case "manufacturer":
                    list.Sort((x, y) => string.Compare(x.Manufacturer, y.Manufacturer));
                    break;
                case "manufacturerRev":
                    list.Sort((x, y) => string.Compare(x.Manufacturer, y.Manufacturer));
                    list.Reverse();
                    break;
                default:
                    break;
            }
            return list;
        }

        /// <summary>
        /// Read the data from the Cereal csv file
        /// </summary>
        /// <returns>Details of specific item</returns>
        public List<Product> GetProduct(string search)
        {
            List<Product> result = GetProducts().Where(x => x.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return result;
        }

        /// <summary>
        /// Get the manufacturer based on the first letter
        /// </summary>
        /// <param name="input">Letter for Manufacturer</param>
        /// <returns>Name of manufacturer</returns>
        public string GetManufacturer(string input)
        {
            string result = "";
            switch (input)
            {
                case "A":
                    result = "American Home Food Products";
                    break;
                case "G":
                    result = "General Mills";
                    break;
                case "K":
                    result = "Kelloggs";
                    break;
                case "N":
                    result = "Nabisco";
                    break;
                case "P":
                    result = "Post";
                    break;
                case "Q":
                    result = "Quaker Oats";
                    break;
                case "R":
                    result = "Ralston Purina";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
