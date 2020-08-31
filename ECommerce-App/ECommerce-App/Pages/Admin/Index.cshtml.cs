using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class IndexModel : PageModel
    {
        private IFlummeryInventory _flummery { get; set; }

        public List<Flummery> Flums { get; set; }

        public IndexModel(IFlummeryInventory flummery)
        {
            _flummery = flummery;
        }


        public async Task OnGet()
        {
            Flums = await _flummery.GetAllFlummeries();
        }
    }
}