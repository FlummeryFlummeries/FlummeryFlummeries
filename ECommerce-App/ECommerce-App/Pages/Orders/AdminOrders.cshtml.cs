using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<AdminOrdersViewModel> Orders { get; set; }
        [BindProperty]
        public string UserNameSearch { get; set; }

        public AdminOrdersModel(IOrder orders, UserManager<ApplicationUser> userManager)
        {
            _orders = orders;
            _userManager = userManager;
        }


        public async Task OnGet()
        {
            var orders = await _orders.GetAllOrders();
            Orders = new List<AdminOrdersViewModel>();
            foreach (var item in orders)
            {
                Orders.Add(new AdminOrdersViewModel
                {
                    Order = item,
                    User = await _userManager.FindByIdAsync(item.UserId)
                });
            }
        }        
        
        public async Task OnPost()
        {
            var user = await _userManager.FindByNameAsync(UserNameSearch);
            var orders = await _orders.GetUserOrders(user.Id);
            Orders = new List<AdminOrdersViewModel>();
            foreach (var item in orders)
            {
                Orders.Add(new AdminOrdersViewModel
                {
                    Order = item,
                    User = await _userManager.FindByIdAsync(item.UserId)
                });
            }
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