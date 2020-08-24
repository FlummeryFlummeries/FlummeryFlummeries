using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_App.Controllers
{
    public class CartController : Controller
    {
        //private readonly ICart _cart;

        //private readonly ICartItem _cartItem;


        //public CartController(ICart cart, ICartItem cartItem)
        //{
        //    _cart = cart;
        //    _cartItem = cartItem;
        //}

        public async Task<IActionResult> Index(string userId)
        {
            //get a Cart that contains all CartItems for a given user from ICart
            return View();
        }

        public async Task<IActionResult> AddToCart(string userId, int qty, int itemId)
        {
            //check with ICart if a cart already exists for this userId, and if not create it
            //create CartItem with payload and join data
            return View();
        }
    }
}
