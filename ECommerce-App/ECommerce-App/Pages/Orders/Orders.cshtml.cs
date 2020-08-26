using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerce_App.Models.Interface;
using System.Security.Policy;
using ECommerce_App.Models;

namespace ECommerce_App.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        private readonly IOrder _order;

        [BindProperty]
        public List<OrderCart> Orders { get; set; }

        public OrdersModel(IOrder order)
        {
            _order = order;
        }

        public async Task<IActionResult> OnPost(string userId)
        {
            Orders = await _order.GetUserOrders(userId);
            return Page();
        }
    }
}
