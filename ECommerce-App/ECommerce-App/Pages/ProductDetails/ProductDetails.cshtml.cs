using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models;

namespace ECommerce_App.Pages.ProductDetails
{
    public class ProductDetailsModel : PageModel
    {
        private IFlummeryInventory _flummeryInventory { get; set; }

        [BindProperty]
        public Flummery Flummery { get; set; }

        /// <summary>
        /// Instantiates a new ProductDetailsModel.
        /// </summary>
        /// <param name="flummeryInventory">
        /// IFlummeryInventory: a service that implements IFlummeryInventory
        /// </param>
        public ProductDetailsModel(IFlummeryInventory flummeryInventory)
        {
            _flummeryInventory = flummeryInventory;
        }

        /// <summary>
        /// Sets the bound Flummery property for the Razor Page.
        /// </summary>
        /// <param name="id">
        /// int: a flummery item ID
        /// </param>
        public async Task OnGet(int id)
        {
            Flummery = await _flummeryInventory.GetFlummeryBy(id);
        }
    }
}
