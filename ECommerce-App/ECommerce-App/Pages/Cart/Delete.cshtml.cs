using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce_App.Pages.Cart
{
    public class DeleteModel : PageModel
    {
        private ICartItem _cartItem;
        private ICart _cart;
        public DeleteModel(ICartItem cartItem, ICart cart)
        {
            _cartItem = cartItem;
            _cart = cart;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string userId, int productId)
        {
            var cart = await _cart.GetUserCart(userId);
            await _cartItem.Delete(cart.Id, productId);
            return RedirectToPage("/Cart/View", new { id = userId });
        }
    }
}