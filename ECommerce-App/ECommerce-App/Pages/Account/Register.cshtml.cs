using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;

        public RegisterModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public void OnGet()
        {
            // Do I need anything on page load besides the normal CSHTML?
        }

        public async Task<IActionResult> OnPost()
        {
            if (Input.Password != Input.ConfirmPassword) return Page();
            ApplicationUser user = new ApplicationUser()
            {
                Email = Input.Email,
                UserName = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName
            };

            var registered = await _userManager.CreateAsync(user, Input.Password);
            if (registered.Succeeded)
            {
                return new LocalRedirectResult("/../..");
            }
            
            return Page();
        }



        public class RegisterViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}