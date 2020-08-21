using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Checkout
{
    public class SuccessModel : PageModel
    {
        private readonly IOrder _order;

        public string Message { get; set; }

        public OrderCart Order { get; set; }


        public SuccessModel(IOrder order)
        {
            _order = order;
        }

        public async Task OnGet(string response, int cartId)
        {
            Message = response;
            Order = await _order.GetUserOrderFor(cartId);
        }
    }
}