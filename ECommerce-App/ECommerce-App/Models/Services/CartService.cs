using ECommerce_App.Data;
using ECommerce_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class CartService : ICart
    {
        private StoreDbContext _context;
        private ICartItem _cartItem;

        /// <summary>
        /// Instantiates a CartService object.
        /// </summary>
        /// <param name="context">
        /// StoreDBContext: an object that inherits from DbContext
        /// </param>
        public CartService(StoreDbContext context, ICartItem cartItem)
        {
            _context = context;
            _cartItem = cartItem;
        }

        /// <summary>
        /// Creates a new cart for a user, called if a cart doesn't already exist for the user in question
        /// </summary>
        /// <param name="cartItem">CartItem information for creation</param>
        /// <returns>Successful result of CartItem creation</returns>
        public async Task<Cart> Create(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return cart;
        }

        /// <summary>
        /// Delete a cart from the database, used when the last item in a 
        /// </summary>
        /// <param name="id">Id of cartItem to be deleted</param>
        /// <returns>Task of completion for cartItem delete</returns>
        public async Task Delete(string userId)
        {
            Cart cart = await _context.Cart.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if(cart != null)
            {
                _context.Entry(cart).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a user's cart from the database
        /// </summary>
        /// <param name="id">Id of cartItem to search for</param>
        /// <returns>Successful result of specified cartItem</returns>
        public async Task<Cart> GetUserCart(string userId)
        {
            var cart = await _context.Cart.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            
            if(cart != null)
            {
                cart.CartItems = await _cartItem.GetUserCartItems(cart.Id);
            }
            return cart;
        }
    }
}
