using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLitePCL;
using static ECommerce_App.Models.Services.PaymentHandlingService;

namespace ECommerce_App.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private IPaymentHandler _payment;

        private ICart _cart;

        private ICartItem _cartItem;

        private IOrder _order;

        private IOrderItem _orderItem;

        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public CheckoutViewModel Input { get; set; }

        public decimal Total { get; set; }

        public CheckoutModel(IPaymentHandler payment, ICart cart, SignInManager<ApplicationUser> signIn, IOrder order, IOrderItem orderItem, ICartItem cartItem)
        {
            _payment = payment;
            _cart = cart;
            _cartItem = cartItem;
            _signInManager = signIn;
            _order = order;
            _orderItem = orderItem;

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
            #region AddressBuilding
            var currentUser = await _signInManager.UserManager.GetUserAsync(User);
            customerAddressType billingAddress = new customerAddressType
            {
                address = Input.BillingAddress,
                firstName = Input.FirstName,
                lastName = Input.LastName,
                email = currentUser.Email,
                state = Input.BillingState,
                zip = Input.BillingZip,
                city = Input.BillingCity,
            };
            customerAddressType shippingAddress = new customerAddressType();
            if (Input.SameBillingAndShipping) shippingAddress = billingAddress;
            else
            {
                shippingAddress.address = Input.ShippingAddress;
                shippingAddress.firstName = Input.FirstName;
                shippingAddress.lastName = Input.LastName;
                shippingAddress.email = currentUser.Email;
                shippingAddress.state = Input.ShippingState;
                shippingAddress.zip = Input.ShippingZip;
                shippingAddress.city = Input.ShippingCity;
            }
            #endregion
            if (ModelState.IsValid)
            {
                var cart = await _cart.GetUserCart(currentUser.Id);
                if (cart != null && cart.CartItems != null)
                {

                    creditCardType card = new creditCardType()
                    {
                        cardNumber = Input.CardNumber,
                        expirationDate = "1220",
                        cardCode = "555"
                    };

                    TransactionResponse result = _payment.Run(card, billingAddress, cart.CartItems);
                    if (result.Successful)
                    {
                        List<CartItem> cartItems = new List<CartItem>();
                        foreach (var item in cart.CartItems)
                        {
                            cartItems.Add(item);
                        }
                        // Delete cart and add order history
                        OrderCart order = new OrderCart()
                        {
                            CartId = cart.Id,
                            UserId = currentUser.Id,
                            FirstName = billingAddress.firstName,
                            LastName = billingAddress.lastName,
                            BillingAddress = billingAddress.address,
                            BillingCity = billingAddress.city,
                            BillingState = billingAddress.state,
                            BillingZip = billingAddress.zip,
                            ShippingAddress = shippingAddress.address,
                            ShippingCity = shippingAddress.city,
                            ShippingState = shippingAddress.state,
                            ShippingZip = shippingAddress.zip
                        };
                        await _order.Create(order);
                        order.CartItems = new List<OrderCartItem>();
                        List<OrderCartItem> orderCartItems = new List<OrderCartItem>();
                        foreach (var item in cartItems)
                        {
                            OrderCartItem orderItem = new OrderCartItem()
                            {
                                OrderCartId = cart.Id,
                                ProductId = item.ProductId,
                                Qty = item.Qty
                            };
                            order.CartItems.Add(orderItem);
                            orderCartItems.Add(orderItem);
                            await _orderItem.Create(orderItem);
                            await _cartItem.Delete(item.CartId, item.ProductId);
                        }                       

                        await _cart.Delete(currentUser.Id);

                        return RedirectToPage("/Checkout/Success", new { response = result.Response, cartId = order.CartId });
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
            public string CardNumber { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Billing Address")]
            public string BillingAddress { get; set; }

            [Required]
            [Display(Name = "Billing Address City")]
            public string BillingCity { get; set; }

            [Required]
            [Display(Name = "Billing Address State")]
            public string BillingState { get; set; }

            [Required]
            [Display(Name = "Billing Address Zip Code")]
            public string BillingZip { get; set; }

            [Display(Name = "Billing Address Line 2")]
            public string BillingOptionalAddition { get; set; }

            [Required]
            [Display(Name = "Same shipping address")]
            public bool SameBillingAndShipping { get; set; }

            [Display(Name = "Shipping Address")]
            public string ShippingAddress { get; set; }

            [Display(Name = "Shipping Address City")]
            public string ShippingCity { get; set; }

            [Display(Name = "Shipping Address State")]
            public string ShippingState { get; set; }

            [Display(Name = "Shipping Address Zip Code")]
            public string ShippingZip { get; set; }

            [Display(Name = "Shipping Address Line 2")]
            public string ShippingOptionalAddition { get; set; }

        }
    }
}