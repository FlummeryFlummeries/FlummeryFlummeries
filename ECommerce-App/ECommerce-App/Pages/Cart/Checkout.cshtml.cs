using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ECommerce_App.Models.Services.PaymentHandlingService;

namespace ECommerce_App.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private IPaymentHandler _payment;
        private ICart _cart;
        private SignInManager<ApplicationUser> _signInManager;
        [BindProperty]
        public CheckoutViewModel Input { get; set; }
        public decimal Total { get; set; }
        public CheckoutModel(IPaymentHandler payment, ICart cart, SignInManager<ApplicationUser> signIn)
        {
            _payment = payment;
            _cart = cart;
            _signInManager = signIn;
        }
        public async Task<IActionResult> OnGet()
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(User);
            var cart = await _cart.GetUserCart(currentUser.Id);
            decimal total = 0;
            foreach (var item in cart.CartItems)
            {
                total += item.Qty * item.Product.Price;
            }
            Total = total;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Input.SameBillingAndShipping) Input.Shipping = Input.Billing;
            if (ModelState.IsValid)
            {
                var currentUser = await _signInManager.UserManager.GetUserAsync(User);
                var cart = await _cart.GetUserCart(currentUser.Id);
                if(cart != null && cart.CartItems != null)
                {
                    creditCardType card = new creditCardType()
                    {
                        cardNumber = Input.CardNumber,
                        expirationDate = "1220",
                        cardCode = "555"
                    };

                    TransactionResponse result = _payment.Run(card, Input.Billing, cart.CartItems, Total);
                    if (result.Successful)
                    {
                        // Delete cart and add order history
                        return RedirectToPage("/Checkout/Success", new { response = result.Response });
                    }
                    else
                    {
                        ModelState.AddModelError("", result.Response);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong! We couldn't find anything in your cart.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid input. Please try again.");
            }
            return Page();
        }

        public class CheckoutViewModel 
        {
            [Required]
            public string CardNumber;

            [Required]
            [Display(Name = "First Name")]
            public string FirstName;

            [Required]
            [Display(Name = "Last name")]
            public string LastName;

            [Required]
            [Display(Name = "Billing Address")]
            public customerAddressType Billing;  
            
            [Required]
            [Display(Name = "Billing Address Line 2")]
            public string BillingOptionalAddition;

            [Required]
            [Display(Name = "Same shipping address")]
            public bool SameBillingAndShipping;

            [Required]
            [Display(Name = "Shipping Address")]
            public customerAddressType Shipping;

            [Required]
            [Display(Name = "Shipping Address Line 2")]
            public string ShippingOptionalAddition;
        }
    }
}