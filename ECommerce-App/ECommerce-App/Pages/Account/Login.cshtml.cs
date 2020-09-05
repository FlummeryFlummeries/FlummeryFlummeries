using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Services;
using ECommerce_App.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerce_App.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Constructor method for Login page
        /// </summary>
        /// <param name="signInManager">SignInManager from ASP.NET identity</param>
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public void OnGet()
        {

        }

        /// <summary>
        /// Sends a login request to ASP.NET identity to attempt to log the user in
        /// </summary>
        /// <returns>Redirect to home page after logging in if successful, display errors if not</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.Persistent, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Email or Password");
            }
            else
            {
                ModelState.AddModelError("", "Invalid attempt.");

            }
            return Page();
        }
    }
}