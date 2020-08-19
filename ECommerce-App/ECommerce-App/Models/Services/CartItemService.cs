using ECommerce_App.Data;
using ECommerce_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class CartItemService : ICartItem
    {
        private StoreDbContext _context;
        private IFlummeryInventory _flummery;

        /// <summary>
        /// Instantiates a CartService object.
        /// </summary>
        /// <param name="context">
        /// StoreDBContext: an object that inherits from DbContext
        /// </param>
        public CartItemService(StoreDbContext context, IFlummeryInventory flummery)
        {
            _context = context;
            _flummery = flummery;
        }

        /// <summary>
        /// Creates a new cart items in the database
        /// </summary>
        /// <param name="cartItem">CartItem information for creation</param>
        /// <returns>Successful result of cartItem creation</returns>
        public async Task Create(CartItem cartItem)
        {
            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete an item from a user's cart
        /// </summary>
        /// <param name="id">Id of cartItem to be deleted</param>
        /// <returns>Task of completion for cartItem delete</returns>
        public async Task Delete(int cartId, int productId)
        {
            
            CartItem item = await _context.CartItems.FindAsync(cartId, productId);
            if(item != null)
            {
                _context.Entry(item).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a list of all the items in a user's card
        /// </summary>       
        /// <param name="cartId">Unique id of card to find items from</param>
        /// <returns>Successful result with list of cartItems</returns>
        public async Task<List<CartItem>> GetUserCartItems(int cartId)
        {
            List<CartItem> items = await _context.CartItems.Where(x => x.CartId == cartId).ToListAsync();
            foreach (var item in items)
            {
                item.Product = await _flummery.GetFlummeryBy(item.ProductId);
            }
            return items;
        }

        /// <summary>
        /// Update a given user's cart item quantity
        /// </summary>
        /// <param name="cartItem">CartItem information for update</param>
        /// <returns>Successful result of specified updated cartItem</returns>
        public async Task Update(CartItem cartItem)
        {
            _context.Entry(cartItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
