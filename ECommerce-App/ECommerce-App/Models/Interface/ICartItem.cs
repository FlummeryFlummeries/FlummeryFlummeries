using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    public interface ICartItem
    {
        /// <summary>
        /// Creates a new stat for a specific character in the database
        /// </summary>
        /// <param name="cartItem">CartItem information for creation</param>
        /// <returns>Successful result of cartItem creation</returns>
        Task<CartItem> Create(CartItem cartItem);

        /// <summary>
        /// Get a list of all of a character's stats in the database
        /// </summary>
        /// <returns>Successful result with list of cartItems</returns>
        Task<List<CartItem>> GetUserCartItems(int cartId);

        /// <summary>
        /// Update a given character's stat in the database
        /// </summary>
        /// <param name="id">Id of cartItem to be updated</param>
        /// <param name="cartItem">CartItem information for update</param>
        /// <returns>Successful result of specified updated cartItem</returns>
        Task<CartItem> Update(CartItem cartItem);

        /// <summary>
        /// Delete a character's stat from the database
        /// </summary>
        /// <param name="id">Id of cartItem to be deleted</param>
        /// <returns>Task of completion for cartItem delete</returns>
        Task Delete(int cartId, int productId);
    }
}
