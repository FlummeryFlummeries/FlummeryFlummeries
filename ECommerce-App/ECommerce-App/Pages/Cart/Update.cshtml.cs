using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Cart
{
    [Authorize]
    public class UpdateModel : PageModel
    {
        private readonly ICart _cart;

        private readonly ICartItem _cartItem;

        private readonly IFlummeryInventory _flummeryInventory;

        /// <summary>
        /// Instantiates a new UpdateModel object
        /// </summary>
        /// <param name="cartItem">
        /// ICartItem: an object that implements the ICartItem interface
        /// </param>
        /// <param name="cart">
        /// ICart: an object that implements the ICart interface
        /// </param>
        /// <param name="flummeryInventory">
        /// IFlummeryInventory: a object that implements the IFlummeryInventory interface
        /// </param>
        public UpdateModel(ICart cart, ICartItem cartItem, IFlummeryInventory flummeryInventory)
        {
            _cart = cart;
            _cartItem = cartItem;
            _flummeryInventory = flummeryInventory;
        }

        /// <summary>
        /// Gets the flummery's for the cart
        /// </summary>
        /// <param name="itemId">
        /// int: the item ID of the flummery to be updated
        /// </param>
        /// <param name="userId">
        /// string: the current user's ID
        /// </param>
        /// <param name="qty">
        /// int: the new quantity, defaults to 1 if no value is passed
        /// </param>
        /// <returns>
        /// Task<IActionResult>: redirects back to the Cart
        /// </returns>
        public async Task<IActionResult> OnGet(int itemId, string userId, int qty = 1)
        {
            if (qty < 1) qty = 1;
            else if (qty > 99) qty = 99;
            var currCart = await _cart.GetUserCart(userId);
            if (currCart == null)
            {
                var newCart = new Models.Cart
                {
                    UserId = userId
                };
                currCart = await _cart.Create(newCart);
            }
            await UpdateCartItems(currCart, itemId, qty);
            return RedirectToPage("/Cart/View");
        }

        /// <summary>
        /// Updates a flummery's quantity in the cart, and returns back to the cart
        /// </summary>
        /// <param name="itemId">
        /// int: the item ID of the flummery to be updated
        /// </param>
        /// <param name="userId">
        /// string: the current user's ID
        /// </param>
        /// <param name="qty">
        /// int: the new quantity, defaults to 1 if no value is passed
        /// </param>
        /// <returns>
        /// Task<IActionResult>: redirects back to the Cart
        /// </returns>
        public async Task<IActionResult> OnPost(int itemId, string userId, int qty = 1)
        {
            if (qty < 1) qty = 1;
            else if (qty > 99) qty = 99;
            var currCart = await _cart.GetUserCart(userId);
            if (currCart == null)
            {
                var newCart = new Models.Cart
                {
                    UserId = userId
                };
                currCart = await _cart.Create(newCart);
            }
            await UpdateCartItems(currCart, itemId, qty);
            return RedirectToPage("/Cart/View");
        }

        /// <summary>
        /// Updates a cart item
        /// </summary>
        /// <param name="cart">
        /// Models.Cart: the current cart
        /// </param>
        /// <param name="itemId">
        /// int: a flummery's item ID
        /// </param>
        /// <param name="qty">
        /// int: the flummery's new quantity
        /// </param>
        private async Task UpdateCartItems(Models.Cart cart, int itemId, int qty)
        {
            bool containsCartItem = false;
            if (cart.CartItems != null)
            {
                foreach (var oneCartItem in cart.CartItems)
                {
                    if (oneCartItem.ProductId == itemId)
                    {
                        oneCartItem.Qty += qty;
                        containsCartItem = true;
                        await _cartItem.Update(oneCartItem);
                        break;
                    }
                }
            }
            if (!containsCartItem)
            {
                var newCartItem = new Models.CartItem
                {
                    CartId = cart.Id,
                    ProductId = itemId,
                    Qty = qty
                };
                await _cartItem.Create(newCartItem);
            }
        }
    }
}