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

        /// <summary>
        /// Instantiates a CartService object.
        /// </summary>
        /// <param name="context">
        /// StoreDBContext: an object that inherits from DbContext
        /// </param>
        public CartItemService(StoreDbContext context)
        {
            _context = context;
        }

        public async Task Create(CartItem cartItem)
        {
            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int cartId, int productId)
        {
            
            CartItem item = await _context.CartItems.FindAsync(cartId, productId);
            if(item != null)
            {
                _context.Entry(item).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CartItem>> GetUserCartItems(int cartId)
        {
            List<CartItem> items = await _context.CartItems.Where(x => x.CartId == cartId).ToListAsync();
            return items;
        }

        public async Task Update(CartItem cartItem)
        {
            _context.Entry(cartItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
