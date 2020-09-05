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
    public class CartIconViewComponent : ViewComponent
    {
        private ICart _cart;

        /// <summary>
        /// Instantiates a new CartIconViewComponent object.
        /// </summary>
        /// <param name="cart">
        /// ICart: an object that implements the ICart interface
        /// </param>
        public CartIconViewComponent(ICart cart)
        {
            _cart = cart;
        }

        /// <summary>
        /// Returns view with the user's cart count
        /// </summary>
        /// <param name="userId">
        /// string: the current user's ID
        /// </param>
        /// <returns>
        /// Task<IViewComponentResult>: a View containing a count of how many items are in the current user's cart
        /// </returns>
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var cart = await _cart.GetUserCart(userId);

            if (cart != null && cart.CartItems != null)
            {
                return View(cart.CartItems.Count);
            }
            return View(0);
        }
    }
}
