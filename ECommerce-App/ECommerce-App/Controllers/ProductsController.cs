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

        public IActionResult Sorted(string type)
        {
            List<Product> list = _product.SortProducts(type);
            return View(list);
        }

        public IActionResult Details(string search)
        {
            List<Product> result = _product.GetProduct(search);
            return View(result);
        }
    }
}
