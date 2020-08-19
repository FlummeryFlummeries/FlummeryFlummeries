using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Cart
{
    public class ViewModel : PageModel
    {
        private ICart _cart;
        private ICartItem _cartItem;
        public Dictionary<Flummery, int> FlummeriesInCart { get; set; }
        [BindProperty]
        public int NewQuantity { get; set; }     
        [BindProperty]
        public int ItemId { get; set; }
        [BindProperty]
        public int CartId { get; set; }

        public ViewModel(ICart cart, ICartItem cartItem)
        {
            _cart = cart;
            _cartItem = cartItem;
            FlummeriesInCart = new Dictionary<Flummery, int>();
        }


        public async Task<IActionResult> OnGet(string userId)
        {
            var cart = await _cart.GetUserCart(userId);
            CartId = cart.Id;
            if(cart == null)
            {
                return Page();
            }
            foreach (CartItem item in cart.CartItems)
            {
                FlummeriesInCart.Add(item.Product, item.Qty);
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(string userId)
        {
            CartItem item = new CartItem()
            {
                CartId = CartId,
                ProductId = ItemId,
                Qty = NewQuantity
            };
            await _cartItem.Update(item);
            return RedirectToPage("/Cart/View", new { id = userId });
        }
    }
}