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

        public UpdateModel(ICart cart, ICartItem cartItem, IFlummeryInventory flummeryInventory)
        {
            _cart = cart;
            _cartItem = cartItem;
            _flummeryInventory = flummeryInventory;
        }

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