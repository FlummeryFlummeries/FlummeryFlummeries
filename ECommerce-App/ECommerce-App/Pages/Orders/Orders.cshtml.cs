using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using ECommerce_App.Models.Interface;
using System.Security.Policy;
using ECommerce_App.Models;

namespace ECommerce_App.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        private readonly IOrder _order;

        

        [BindProperty]
        public List<OrderCart> DisplayedOrders { get; set; }

        [BindProperty]
        public int CurrPage { get; set; }

        public int ItemsPerPage { get; set; } = 5;

        public int TotalPages { get; private set; }


        public OrdersModel(IOrder order)
        {
            _order = order;
        }

        //public async Task<IActionResult> OnGet(string userId, int nextPage)
        //{
        //    await GetOrdersForUserAndPage(userId, nextPage);
        //    return Page();
        //}

        public async Task<IActionResult> OnPost(string userId, int page)
        {
            await GetOrdersForUserAndPage(userId, page);
            return Page();
        }

        private async Task GetOrdersForUserAndPage(string userId, int page)
        {
            CurrPage = page;
            var allOrders = await _order.GetUserOrders(userId);

            DisplayedOrders = allOrders.Skip((CurrPage - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();

            TotalPages = (int)Math.Ceiling(decimal.Divide(allOrders.Count, ItemsPerPage));
        }
    }
}
