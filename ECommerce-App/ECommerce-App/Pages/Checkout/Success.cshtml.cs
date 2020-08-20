using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Checkout
{
    public class SuccessModel : PageModel
    {
        public string Message;
        public void OnGet(string response)
        {
            Message = response;
        }
    }
}