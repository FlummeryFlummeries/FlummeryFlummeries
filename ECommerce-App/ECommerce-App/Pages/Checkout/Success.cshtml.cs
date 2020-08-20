using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Checkout
{
    public class SuccessModel : PageModel
    {
        public string Message;

        public OrderCart Order;

        public void OnGet(string response, OrderCart order)
        {
            Message = response;
            Order = order;
        }
    }
}