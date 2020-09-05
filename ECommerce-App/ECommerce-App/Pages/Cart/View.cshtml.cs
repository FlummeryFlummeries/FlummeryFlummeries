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

        /// <summary>
        /// Instantiates a new ViewModel object.
        /// </summary>
        /// <param name="cartItem">
        /// ICartItem: an object that implements the ICartItem interface
        /// </param>
        /// <param name="cart">
        /// ICart: an object that implements the ICart interface
        /// </param>
        /// <param name="signIn">
        /// SignInManager<ApplicationUser>: a SignInManager object
        /// </param>
        public ViewModel(ICart cart, ICartItem cartItem, SignInManager<ApplicationUser> signIn)
        {
            _cart = cart;
            _cartItem = cartItem;
            _signInManager = signIn;
            FlummeriesInCart = new List<CartItem>();
        }

        /// <summary>
        /// Gets the current cart for the current user.
        /// </summary>
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

        /// <summary>
        /// Updates a CartItem.
        /// </summary>
        /// <param name="userId">
        /// string: the user ID of the current user
        /// </param>
        /// <returns>
        /// Task<IActionResult>: redirects back to the cart
        /// </returns>
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