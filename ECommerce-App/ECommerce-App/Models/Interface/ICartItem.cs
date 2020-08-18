using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    public interface ICartItem
    {
        /// <summary>
        /// Creates a new cart items in the database
        /// </summary>
        /// <param name="cartItem">CartItem information for creation</param>
        /// <returns>Successful result of cartItem creation</returns>
        Task Create(CartItem cartItem);

        /// <summary>
        /// Get a list of all the items in a user's card
        /// </summary>       
        /// <param name="cartId">Unique id of card to find items from</param>
        /// <returns>Successful result with list of cartItems</returns>
        Task<List<CartItem>> GetUserCartItems(int cartId);

        /// <summary>
        /// Update a given user's cart item quantity
        /// </summary>
        /// <param name="cartItem">CartItem information for update</param>
        /// <returns>Successful result of specified updated cartItem</returns>
        Task Update(CartItem cartItem);

        /// <summary>
        /// Delete an item from a user's cart
        /// </summary>
        /// <param name="id">Id of cartItem to be deleted</param>
        /// <returns>Task of completion for cartItem delete</returns>
        Task Delete(int cartId, int productId);
    }
}
