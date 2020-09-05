using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
    public class AdminOrdersViewModel
    {
        [BindProperty]
        public OrderCart Order { get; set; }
        [BindProperty]
        public ApplicationUser User { get; set; }
    }
}
