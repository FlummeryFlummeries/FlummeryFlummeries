using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Checkout
{
    [Authorize]
    public class SuccessModel : PageModel
    {
        private readonly IOrder _order;

        public string Message { get; set; }

        public OrderCart Order { get; set; }


        public SuccessModel(IOrder order)
        {
            _order = order;
        }

        /// <summary>
        /// Receive and display the success message and Order from the checkout
        /// </summary>
        /// <param name="response">AuthorizeNet success response string</param>
        /// <param name="cartId">Current user's cartId to get the order</param>
        /// <returns>Binds Message and Order to page for displaying on front end</returns>
        public async Task OnGet(string response, int cartId)
        {
            Message = response;
            Order = await _order.GetUserOrderFor(cartId);
        }
    }
}