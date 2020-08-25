using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using ECommerce_App.Models;
using ECommerce_App.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Account
{
    [Authorize]
    public class ViewModel : PageModel
    {
        public UserManager<ApplicationUser> _userManager { get; set; }

        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public AccountInfoViewModel Input { get; set; }

        public ViewModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGet()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var claims = await _userManager.GetClaimsAsync(currentUser);

            Input = new AccountInfoViewModel
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            currentUser.FirstName = Input.FirstName;
            currentUser.LastName = Input.LastName;
            currentUser.Email = Input.Email;
            currentUser.UserName = Input.Email;

            //_signInManager.UserManager.ChangePasswordAsync

            var result = await _userManager.UpdateAsync(currentUser);
            if (result.Succeeded)
            {
                var claims = await _userManager.GetClaimsAsync(currentUser);

                Claim nameClaim = claims.Where(x => x.Type == "FullName").FirstOrDefault();

                await _userManager.RemoveClaimAsync(currentUser, nameClaim);

                Claim newClaim = new Claim("FullName", $"{Input.FirstName} {Input.LastName}");
                await _userManager.AddClaimAsync(currentUser, newClaim);
                await _signInManager.RefreshSignInAsync(currentUser);

            }

            return Page();
        }
    }
}