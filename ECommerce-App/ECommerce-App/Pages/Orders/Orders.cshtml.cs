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
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce_App.Pages.Orders
{
    [Authorize]
    public class OrdersModel : PageModel
    {
        private readonly IOrder _order;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public List<OrderCart> DisplayedOrders { get; set; }

        [BindProperty]
        public int CurrPage { get; set; }

        [BindProperty]
        public string UserEmail { get; set; }

        public int ItemsPerPage { get; set; } = 5;

        public int TotalPages { get; private set; }


        public OrdersModel(IOrder order, UserManager<ApplicationUser> userManager)
        {
            _order = order;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost(int page, string userEmail = null)
        {
            ApplicationUser user;
            if(userEmail == null || userEmail == "")
            {
                user = await _userManager.GetUserAsync(User);
            }
            else
            {
                user = await _userManager.FindByEmailAsync(userEmail);
                UserEmail = user.Email;
                if(user == null)
                {
                    return RedirectToPage("/Orders/AdminOrders");
                }
            }
            await GetOrdersForUserAndPage(user.Id, page);
            return Page();
        }

        private async Task GetOrdersForUserAndPage(string userEmail, int page)
        {
            CurrPage = page;
            var allOrders = await _order.GetUserOrders(userEmail);

            DisplayedOrders = allOrders.Skip((CurrPage - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();

            TotalPages = (int)Math.Ceiling(decimal.Divide(allOrders.Count, ItemsPerPage));
        }
    }
}
