using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Uploads
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private IFlummeryInventory _flummery;

        public DeleteModel(IFlummeryInventory flummery)
        {
            _flummery = flummery;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            await _flummery.DeleteFlummery(id);
            return RedirectToAction("Index", "Products");
        }
    }
}