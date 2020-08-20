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

        TransactionResponse Run(creditCardType card, customerAddressType billingAddress, List<CartItem> cartItems, decimal total);
    }
}
