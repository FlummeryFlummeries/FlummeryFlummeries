using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Xml.Schema;
using AuthorizeNet.Api.Contracts.V1;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid.Helpers.Mail;
using SQLitePCL;
using static ECommerce_App.Models.Services.PaymentHandlingService;
using static ECommerce_App.Models.Services.Emails.ReceiptTemplateData;
using ECommerce_App.Models.Services.Emails;
using ECommerce_App.Models.ViewModels;
using ECommerce_App.Models.Emails;

namespace ECommerce_App.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private IPaymentHandler _payment;

        private ICart _cart;

        private ICartItem _cartItem;

        private IOrder _order;

        private IOrderItem _orderItem;

        private IEmail _email;

        private SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public CheckoutViewModel Input { get; set; }

        public decimal Total { get; set; }

        public CheckoutModel(IPaymentHandler payment, ICart cart, SignInManager<ApplicationUser> signIn, IOrder order, IOrderItem orderItem, ICartItem cartItem, IEmail email)
        {
            _payment = payment;
            _cart = cart;
            _cartItem = cartItem;
            _signInManager = signIn;
            _order = order;
            _orderItem = orderItem;
            _email = email;

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
                        decimal total = 0;
                        List<CartItem> cartItems = new List<CartItem>();
                        foreach (var item in cart.CartItems)
                        {
                            cartItems.Add(item);
                            total += item.Qty * item.Product.Price;
                        }

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
                        foreach (var item in cartItems)
                        {
                            OrderCartItem orderItem = new OrderCartItem()
                            {
                                OrderCartId = cart.Id,
                                ProductId = item.ProductId,
                                Qty = item.Qty
                            };
                            order.CartItems.Add(orderItem);
                            await _orderItem.Create(orderItem);
                            await _cartItem.Delete(item.CartId, item.ProductId);
                        }

                        await _cart.Delete(currentUser.Id);

                        await BuildCheckoutEmail(currentUser.Email, $"{order.FirstName} {order.LastName}", cartItems, $"{shippingAddress.address} {shippingAddress.city}, {shippingAddress.state} {shippingAddress.zip}", total);

                        return RedirectToPage("/Checkout/Success", new { response = result.Response, cartId = cart.Id });
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

        public async Task BuildCheckoutEmail(string emailAddress, string name, List<CartItem> items, string address, decimal total)
        {
            List<EmailItem> newItems = new List<EmailItem>();
            string templateId = "d-baa668b986ef47f79ef56df8a2674db8";
            foreach (var item in items)
            {
                newItems.Add(new EmailItem
                {
                    ImgSrc = item.Product.ImageUrl,
                    Qty = item.Qty,
                    ItemName = item.Product.Name,
                    ItemTotal = item.Qty * item.Product.Price
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
                TemplateData = new ReceiptTemplateData()
                {
                    FullName = name,
                    Date = DateTime.Now.ToString(),
                    Address = address,
                    Total = total,
                    CartItems = newItems
                }
            });
            await _email.SendEmail(templateId, personalizations);
        }
    }
}