using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Orders
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminOrdersModel : PageModel
    {
        private IOrder _orders;
        private UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public int CurrPage { get; set; }

        public int ItemsPerPage { get; set; } = 5;

        public int TotalPages { get; private set; }

        [BindProperty]
        public List<AdminOrdersViewModel> Orders { get; set; }
        [BindProperty]
        public string UserNameSearch { get; set; }

        public AdminOrdersModel(IOrder orders, UserManager<ApplicationUser> userManager)
        {
            _orders = orders;
            _userManager = userManager;
            Orders = new List<AdminOrdersViewModel>();
        }


        public async Task OnGet(int page)
        {
            await HandlePagination(page);
        }        
        
        public async Task OnPost(int page)
        {
            var user = await _userManager.FindByNameAsync(UserNameSearch);
            await HandlePagination(page, user.Id);
        }

        public async Task HandlePagination(int page, string userId = null)
        {
            CurrPage = page;
            List<OrderCart> orders;
            if(userId != null)
            {
                orders = await _orders.GetUserOrders(userId);
            }
            else
            {
                orders = await _orders.GetAllOrders();
            }

            var displayedOrders = orders.Skip((CurrPage - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();

            foreach (var item in displayedOrders)
            {
                Orders.Add(new AdminOrdersViewModel
                {
                    Order = item,
                    User = await _userManager.FindByIdAsync(item.UserId)
                });
            }
            TotalPages = (int)Math.Ceiling(decimal.Divide(orders.Count, ItemsPerPage));
        }
    }

    public class AdminOrdersViewModel
    {
        [BindProperty]
        public OrderCart Order { get; set; }     
        [BindProperty]
        public ApplicationUser User { get; set; }
    }
}