using System;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signIn)
        {
            _signInManager = signIn;
        }
        
        /// <summary>
        /// Log the user out
        /// </summary>
        /// <returns>Redirect to homepage after logging out</returns>
        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Log the user out
        /// </summary>
        /// <returns>Redirect to homepage after logging out</returns>
        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}