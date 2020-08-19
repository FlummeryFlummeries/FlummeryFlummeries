using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    public interface ICart
    {
        /// <summary>
        /// Creates a new cart for a user, called if a cart doesn't already exist for the user in question
        /// </summary>
        /// <param name="cartItem">CartItem information for creation</param>
        /// <returns>Successful result of CartItem creation</returns>
        Task Create(Cart cart);

        /// <summary>
        /// Get a user's cart from the database
        /// </summary>
        /// <param name="id">Id of cartItem to search for</param>
        /// <returns>Successful result of specified cartItem</returns>
        Task<Cart> GetUserCart(string userId);

        /// <summary>
        /// Delete a cart from the database, used when the last item in a 
        /// </summary>
        /// <param name="id">Id of cartItem to be deleted</param>
        /// <returns>Task of completion for cartItem delete</returns>
        Task Delete(string userId);

    }
}
