using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Cart
{
    public class DeleteModel : PageModel
    {
        // private ICart _cart;
        public DeleteModel()
        {
            // _cart = cart;
        }
        public void OnGet(int id)
        {
            // _cart.Delete(id);
            // return RedirectToPage("/Cart/View")
        }
    }
}