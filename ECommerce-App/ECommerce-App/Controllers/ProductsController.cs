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
        public IProduct _product { get; set; }

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        public IActionResult Index()
        {
            List<Product> list = _product.GetProducts();
            return View(list);
        }

        public IActionResult Details(List<Product> list)
        {
            list.Sort((x, y) => string.Compare(x.Name, y.Name));
            return View(list);
        }

        public IActionResult Sorted(List<Product> list, string search)
        {
            var result = list.Where(x => x.Name == search);
            return View(result);
        }


    }
}
