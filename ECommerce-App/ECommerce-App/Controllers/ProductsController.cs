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
        /// Constructor for ProductsController
        /// </summary>
        /// <param name="flummery">Interface for flummeries</param>
        public ProductsController(IFlummeryInventory flummery)
        {
            _flummery = flummery;
        }

        /// <summary>
        /// Get all of the flummeries and display them to the page
        /// </summary>
        /// <returns>View with a model consisting of all flummeries in DB</returns>
        public async Task<IActionResult> Index()
        {
            List<Flummery> list = await _flummery.GetAllFlummeries();
            return View(list);
        }

        /// <summary>
        /// Order flummeries when the user selects a sort method
        /// </summary>
        /// <param name="type">How the flummeries should be sorted</param>
        /// <returns>View with a model consisting of all flummeries sorted in a given way.</returns>
        [HttpPost]
        public async Task<IActionResult> Index(string type)
        {
            List<Flummery> list = await _flummery.GetFlummeriesOrderedBy(type);
            return View(list);
        }

        /// <summary>
        /// Search for a specific individual flummeries or group of flummeries by a search term
        /// </summary>
        /// <param name="search">Search term</param>
        /// <returns>View with a model consisting of all flummeries with given search term in name</returns>
        public async Task<IActionResult> Details(string search)
        {
            List<Flummery> list = await _flummery.GetFlummeriesForSearch(search);
            return View(list);
        }
    }
}
