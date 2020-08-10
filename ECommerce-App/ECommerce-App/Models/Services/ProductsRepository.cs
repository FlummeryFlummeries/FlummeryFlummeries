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
                    Manufacturer = split[1],
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
    }

    public enum Manufacturer
    {
        
    }
}
