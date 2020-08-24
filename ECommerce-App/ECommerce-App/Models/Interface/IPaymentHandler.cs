using AuthorizeNet.Api.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ECommerce_App.Models.Services.PaymentHandlingService;

namespace ECommerce_App.Models.Interface
{
    public interface IPaymentHandler
    {
        /// <summary>
        /// Run a credit card through AuthorizeNet
        /// </summary>
        /// <param name="card">Credit card to be run, includes number, exp date and CVV in object</param>
        /// <param name="billingAddress">Billing address of purchaser, contains address, city, state, zip, user's name and email in object</param>
        /// <param name="cartItems">Cart items to be turned into LineItems</param>
        /// <returns>Transaction response containing a boolean representing if the payment was successful, and a string with the response message</returns>
        TransactionResponse Run(creditCardType card, customerAddressType billingAddress, List<CartItem> cartItems);
    }
}
