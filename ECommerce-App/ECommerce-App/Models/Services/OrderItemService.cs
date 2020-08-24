using ECommerce_App.Data;
using ECommerce_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class OrderItemService : IOrderItem
    {
        private StoreDbContext _context;
        private IFlummeryInventory _flummery;

        /// <summary>
        /// Instantiates a OrderService object.
        /// </summary>
        /// <param name="context">
        /// StoreDBContext: an object that inherits from DbContext
        /// </param>
        public OrderItemService(StoreDbContext context, IFlummeryInventory flummery)
        {
            _context = context;
            _flummery = flummery;
        }

        /// <summary>
        /// Creates a new order items in the database
        /// </summary>
        /// <param name="orderItem">OrderItem information for creation</param>
        /// <returns>Successful result of orderItem creation</returns>
        public async Task Create(OrderCartItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete an item from a user's order
        /// </summary>
        /// <param name="id">Id of orderItem to be deleted</param>
        /// <returns>Task of completion for orderItem delete</returns>
        public async Task Delete(int orderId, int productId)
        {

            OrderCartItem item = await _context.OrderCartItem.FindAsync(orderId, productId);
            if (item != null)
            {
                _context.Entry(item).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a list of all the items in a user's card
        /// </summary>       
        /// <param name="orderId">Unique id of order to find items from</param>
        /// <returns>Successful result with list of orderItems</returns>
        public async Task<List<OrderCartItem>> GetUserOrderItems(int orderId)
        {
            List<OrderCartItem> items = await _context.OrderCartItem.Where(x => x.OrderCartId == orderId).ToListAsync();
            foreach (var item in items)
            {
                item.Product = await _flummery.GetFlummeryBy(item.ProductId);
            }
            return items;
        }

        /// <summary>
        /// Update a given user's order item quantity
        /// </summary>
        /// <param name="orderItem">OrderItem information for update</param>
        /// <returns>Successful result of specified updated orderItem</returns>
        public async Task Update(OrderCartItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
