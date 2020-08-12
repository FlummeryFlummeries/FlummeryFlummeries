using System;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CerealECommerce.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signIn)
        {
            _signInManager = signIn;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}