using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    public interface IOrderItem
    {
        /// <summary>
        /// Creates a new order items in the database
        /// </summary>
        /// <param name="orderItem">OrderCartItem information for creation</param>
        /// <returns>Successful result of orderItem creation</returns>
        Task Create(OrderCartItem orderItem);

        /// <summary>
        /// Get a list of all the items in a user's card
        /// </summary>       
        /// <param name="orderId">Unique id of order to find items from</param>
        /// <returns>Successful result with list of orderItems</returns>
        Task<List<OrderCartItem>> GetUserOrderItems(int orderId);

        /// <summary>
        /// Update a given user's order item quantity
        /// </summary>
        /// <param name="orderItem">OrderCartItem information for update</param>
        /// <returns>Successful result of specified updated orderItem</returns>
        Task Update(OrderCartItem orderItem);

        /// <summary>
        /// Delete an item from a user's order
        /// </summary>
        /// <param name="id">Id of orderItem to be deleted</param>
        /// <returns>Task of completion for orderItem delete</returns>
        Task Delete(int orderId, int productId);
    }
}
