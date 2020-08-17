using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_App.Controllers
{
    public class ProductsController : Controller
    {
        public IFlummeryInventory _flummery { get; set; }

        public ProductsController(IFlummeryInventory flummery)
        {
            _flummery = flummery;
        }


        public async Task<IActionResult> Index()
        {
            List<Flummery> list = await _flummery.GetAllFlummeries();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string type)
        {
            List<Flummery> list = await _flummery.GetFlummeriesOrderedBy(type);
            return View(list);
        }

        public async Task<IActionResult> Details(string search)
        {
            List<Flummery> list = await _flummery.GetFlummeriesForSearch(search);
            return View(list);
        }
    }
}
