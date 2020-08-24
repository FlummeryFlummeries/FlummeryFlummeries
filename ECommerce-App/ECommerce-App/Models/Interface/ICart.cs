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
        /// <param name="cartItem">Cart information for creation</param>
        /// <returns>Successful result of Cart creation</returns>
        Task<Cart> Create(Cart cart);

        /// <summary>
        /// Get a user's cart from the database
        /// </summary>
        /// <param name="id">Id of user to search for a cart for</param>
        /// <returns>Successful result of specified cart</returns>
        Task<Cart> GetUserCart(string userId);

        /// <summary>
        /// Delete a cart from the database, used when the last item in a cart is removed or a checkout is successful
        /// </summary>
        /// <param name="id">Id of cart to be deleted</param>
        /// <returns>Task of completion for cart deletion</returns>
        Task Delete(string userId);

    }
}
