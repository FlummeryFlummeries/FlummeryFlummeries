using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Cart
{
    public class ViewModel : PageModel
    {
        // private ICart _cart;
        public List<Flummery> FlummeriesInCart { get; set; }

        public ViewModel()
        {
            // _cart = cart;
        }
        public void OnGet()
        {
            // FlummeriesInCart = await _cart.GetUserCart();
            
        }
    }
}