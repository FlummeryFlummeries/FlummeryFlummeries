using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    public interface IOrder
    {
        /// <summary>
        /// Creates a new order for a user, called when checkoout is successful and a cart is turned into an order
        /// </summary>
        /// <param name="orderItem">OrderItem information for creation</param>
        /// <returns>Successful result of OrderItem creation</returns>
        Task<OrderCart> Create(OrderCart order);

        /// <summary>
        /// Get a user's orders from the database.
        /// </summary>
        /// <param name="id">
        /// string: the userId
        /// </param>
        /// <returns>
        /// List<OrderCart>: a List of OrderCart entity objects
        /// </returns>
        Task<List<OrderCart>> GetUserOrders(string userId);

        /// <summary>
        /// Get a specific user's order from the database
        /// </summary>
        /// <param name="userId">Id of order item to search for</param>
        /// <param name="orderId">Id of order item to search for</param>
        /// <returns>Successful result of specified orderItem</returns>
        Task<OrderCart> GetUserOrderFor(int cardId);

        /// <summary>
        /// Delete a order from the database, used when the last item in a 
        /// </summary>
        /// <param name="id">Id of order item to be deleted</param>
        /// <returns>Task of completion for orderItem delete</returns>
        Task Delete(string userId, int orderId);

        /// <summary>
        /// Get all orders for Admin viewing
        /// </summary>
        /// <returns>Successful result of list of all OrderCarts</returns>
        Task<List<OrderCart>> GetAllOrders();
    }
}
