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

        /// <summary>
        /// Instantiates a new ProductsController object.
        /// </summary>
        /// <param name="flummery"></param>
        public ProductsController(IFlummeryInventory flummery)
        {
            _flummery = flummery;
        }

        /// <summary>
        /// Displays all the flummeries in a View.
        /// </summary>
        /// <returns>
        /// Task<IActionResult>: a list of all flummeries
        /// </returns>
        public async Task<IActionResult> Index()
        {
            List<Flummery> list = await _flummery.GetAllFlummeries();
            return View(list);
        }

        /// <summary>
        /// Displays all the flummeries sorted by the parameter string
        /// </summary>
        /// <param name="type">
        /// string: how to sort the flummeries
        /// </param>
        /// <returns>
        /// Task<IActionResult>: a list of all flummeries, sorted
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Index(string type)
        {
            List<Flummery> list = await _flummery.GetFlummeriesOrderedBy(type);
            return View(list);
        }

        /// <summary>
        /// Gets a subset of the flummeries from the parameter string
        /// </summary>
        /// <param name="search">
        /// string: the serach string used to match flummeries against
        /// </param>
        /// <returns>
        /// Task<IActionResult>: a subset of flummeries that match the search string
        /// </returns>
        public async Task<IActionResult> Details(string search)
        {
            List<Flummery> list = await _flummery.GetFlummeriesForSearch(search);
            return View(list);
        }
    }
}
