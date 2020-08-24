using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Cart
{
    [Authorize]
    public class ViewModel : PageModel
    {
        private ICart _cart;
        private ICartItem _cartItem;
        private SignInManager<ApplicationUser> _signInManager;
        public List<CartItem> FlummeriesInCart { get; set; }
        [BindProperty]
        public int NewQuantity { get; set; }     
        [BindProperty]
        public int ItemId { get; set; }
        [BindProperty]
        public int CartId { get; set; }
        [BindProperty]
        public string UserId { get; set; }

        public ViewModel(ICart cart, ICartItem cartItem, SignInManager<ApplicationUser> signIn)
        {
            _cart = cart;
            _cartItem = cartItem;
            _signInManager = signIn;
            FlummeriesInCart = new List<CartItem>();
        }


        public async Task<IActionResult> OnGet()
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(User);
            var cart = await _cart.GetUserCart(currentUser.Id);
            CartId = cart.Id;
            if(cart == null)
            {
                return Page();
            }
            foreach (CartItem item in cart.CartItems)
            {
                FlummeriesInCart.Add(item);
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
            return RedirectToPage("/Cart/View");
        }
    }
}