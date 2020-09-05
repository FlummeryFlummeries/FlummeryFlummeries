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

        /// <summary>
        /// Instantiates a new CartViewComponent object.
        /// </summary>
        /// <param name="cart">
        /// ICart: an object that implements the ICart interface
        /// </param>
        public CartViewComponent(ICart cart)
        {
            _cart = cart;
        }

        /// <summary>
        /// Gets the current user's cart items.
        /// </summary>
        /// <param name="userId">
        /// string: the current user's ID
        /// </param>
        /// <returns>
        /// Task<IViewComponentResult>: a View containing the current user's cart items
        /// </returns>
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var cart = await _cart.GetUserCart(userId);

            if(cart != null)
            {
                return View(cart.CartItems);
            }
            return View(new List<CartItem>());
        }
    }
}
