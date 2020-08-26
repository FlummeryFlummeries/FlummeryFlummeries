using ECommerce_App.Data;
using ECommerce_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class OrderService : IOrder
    {
        private StoreDbContext _context;
        private IOrderItem _orderItem;

        /// <summary>
        /// Instantiates a OrderService object.
        /// </summary>
        /// <param name="context">
        /// StoreDBContext: an object that inherits from DbContext
        /// </param>
        public OrderService(StoreDbContext context, IOrderItem orderItem)
        {
            _context = context;
            _orderItem = orderItem;
        }

        /// <summary>
        /// Creates a new order for a user, called if a order doesn't already exist for the user in question
        /// </summary>
        /// <param name="orderItem">OrderItem information for creation</param>
        /// <returns>Successful result of OrderItem creation</returns>
        public async Task<OrderCart> Create(OrderCart order)
        {
            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Delete a order from the database, used when the last item in a 
        /// </summary>
        /// <param name="id">Id of orderItem to be deleted</param>
        /// <returns>Task of completion for orderItem delete</returns>
        public async Task Delete(string userId, int orderId)
        {
            OrderCart order = await _context.OrderCart.FindAsync(userId, orderId);

            if (order != null)
            {
                _context.Entry(order).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a user's orders from the database
        /// </summary>
        /// <param name="id">
        /// Id of orderItem to search for
        /// </param>
        /// <returns>
        /// Successful result of specified orderItem
        /// </returns>
        public async Task<List<OrderCart>> GetUserOrders(string userId)
        {
            var orders = await _context.OrderCart.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CartId)
                .ToListAsync();
            if (orders == null)
            {
                return orders;
            }
            foreach (var order in orders)
            {
                if (order != null)
                {
                    order.CartItems = await _orderItem.GetUserOrderItems(order.Id);
                }
            }
            return orders;
        }      
        
        /// <summary>
        /// Get a specific user's order from the database
        /// </summary>
        /// <param name="id">Id of orderItem to search for</param>
        /// <returns>Successful result of specified orderItem</returns>
        public async Task<OrderCart> GetUserOrderFor(int cardId)
        {
            var order = await _context.OrderCart.Where(x => x.CartId == cardId).FirstOrDefaultAsync();
            if (order != null)
            {
                order.CartItems = await _orderItem.GetUserOrderItems(order.Id);
            }
            return order;
        }
    }
}
