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
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce_App.Pages.Cart
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private ICartItem _cartItem;
        private ICart _cart;
        private SignInManager<ApplicationUser> _signInManager;

        public DeleteModel(ICartItem cartItem, ICart cart, SignInManager<ApplicationUser> signIn)
        {
            _cartItem = cartItem;
            _cart = cart;
            _signInManager = signIn;

        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(int productId)
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(User);
            var cart = await _cart.GetUserCart(currentUser.Id);
            if(cart.CartItems.Count <= 1)
            {
                await _cart.Delete(currentUser.Id);
            }
            await _cartItem.Delete(cart.Id, productId);
            return RedirectToPage("/Cart/View");
        }
    }
}