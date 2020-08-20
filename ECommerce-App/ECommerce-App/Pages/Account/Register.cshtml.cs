using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmail _email;

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmail email)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _email = email;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
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
                    Claim claim = new Claim("FullName", $"{Input.FirstName} {Input.LastName}");

                    await _userManager.AddClaimAsync(user, claim);

                    await _signInManager.SignInAsync(user, Input.Persistent);

                    string emailSubject = "Thanks for registering at Flummery Flummeries!";

                    string emailMessage = $"<p>Thank you {Input.FirstName} {Input.LastName} for registering with Flummery Flummeries!</p>";

                    await _email.SendEmail(Input.Email, emailSubject, emailMessage);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Registration. Email may already be in use.");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Registration. Please try again.");
            }
            return Page();
        }



        public class RegisterViewModel
        {
            [Required]
            [Display(Name = "Email Address")]
            [EmailAddress]
            public string Email { get; set; }


            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            // These are like server side versions of adding required and type="password" to the inputs on the front end
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            [Display(Name = "Confirm Password")]
            public string ConfirmPassword { get; set; }

            public bool Persistent { get; set; }
        }
    }
}