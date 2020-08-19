using ECommerce_App.Data;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.ViewComponents
{
    [ViewComponent]
    public class CartViewComponent : ViewComponent
    {
        private ICart _cart;

        public CartViewComponent(ICart cart)
        {
            _cart = cart;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var cart = await _cart.GetUserCart(userId);

            return View(cart.CartItems);
        }
    }
}
