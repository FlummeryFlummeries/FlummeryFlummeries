using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Emails;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid.Helpers.Mail;

namespace ECommerce_App.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmail _email;
        private IFlummeryInventory _flummery;

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmail email, IFlummeryInventory flummery)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _email = email;
            _flummery = flummery;
        }


        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public void OnGet()
        {
        }

        /// <summary>
        /// Register a new user with a given email, first and last name, and password
        /// </summary>
        /// <returns>Redirect to home after logging user in if successful, show modelstate errors on form if unsuccessful</returns>
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

                    await BuildRegistrationEmail(Input.Email, $"{Input.FirstName} {Input.LastName}");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in registered.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Registration. Please try again.");
            }
            return Page();
        }

        public async Task BuildRegistrationEmail(string emailAddress, string name)
        {
            string templateId = "d-d26e9bcbfef6438ab53fd65fca39da27";

            List<EmailItem> featuredFlums = new List<EmailItem>();
            List<int> usedNums = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                int temp = rand.Next(1, 10);
                while (usedNums.Contains(temp))
                {
                    temp = rand.Next(1, 10);
                }
                usedNums.Add(temp);
                Flummery flum = await _flummery.GetFlummeryBy(temp);
                featuredFlums.Add(new EmailItem{
                    Id = flum.Id,
                    ImgSrc = flum.ImageUrl,
                    ItemName = flum.Name,
                    ItemPrice = flum.Price
                });
            }

            List<Personalization> personalizations = new List<Personalization>();
            personalizations.Add(new Personalization()
            {
                Tos = new List<EmailAddress>
                {
                    new EmailAddress(emailAddress)
                },
                Subject = "Thanks for your purchase!",
                TemplateData = new RegistrationTemplateData()
                {
                    FullName = name,
                    Date = DateTime.Now.ToString(),
                    DisplayItems = featuredFlums
                }
            });
            await _email.SendEmail(templateId, personalizations);
        }
    }
}