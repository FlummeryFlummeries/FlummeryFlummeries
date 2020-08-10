using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_App.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
            string[] myFile = System.IO.File.ReadAllLines(newPath);
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


            return View(list);
        }

        public IActionResult Details(Product product)
        {
            return View(product);
        }


    }
}
