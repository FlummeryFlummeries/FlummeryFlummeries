using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Account
{
    [Authorize]
    public class PasswordModel : PageModel
    {
        public UserManager<ApplicationUser> _userManager { get; set; }

        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public PasswordChangeViewModel Input { get; set; }

        public PasswordModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var result = await _signInManager.UserManager.ChangePasswordAsync(currentUser, Input.ConfirmPassword, Input.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Account/View");
                }
                ModelState.AddModelError("", "Invalid Current Password.");
                return Page();
            }
            ModelState.AddModelError("", "Invalid attempt");
            return Page();
        }
    }
}