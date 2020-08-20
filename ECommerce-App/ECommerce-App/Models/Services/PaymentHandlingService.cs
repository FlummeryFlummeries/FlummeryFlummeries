using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using ECommerce_App.Models.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class PaymentHandlingService : IPaymentHandler
    {
        private IConfiguration _config;

        public PaymentHandlingService(IConfiguration config)
        {
            _config = config;
        }


        public TransactionResponse Run(creditCardType card, customerAddressType billingAddress, List<CartItem> cartItems, decimal total)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _config["AuthorizeNet:LoginId"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["AuthorizeNet:TransactionKey"]
            };

            paymentType paymentType = new paymentType { Item = card };
            lineItemType[] lineItems = new lineItemType[cartItems.Count];
            for (int i = 0; i < cartItems.Count; i++)
            {
                CartItem item = cartItems[i];
                lineItems[i] = new lineItemType { itemId = item.ProductId.ToString(), name = item.Product.Name, quantity = item.Qty, unitPrice = item.Product.Price };
            }

            transactionRequestType transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = total,
                payment = paymentType,
                billTo = billingAddress,
                lineItems = lineItems
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            createTransactionController controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.transactionResponse != null)
                {
                    return new TransactionResponse {
                        Successful = true,
                        Response = $"Authorization code: {response.transactionResponse.authCode}"
                    };
                }
            }
            else if (response.transactionResponse != null)
            {
                return new TransactionResponse
                {
                    Successful = false,
                    Response = $"Transaction Error: {response.transactionResponse.errors[0].errorCode} {response.transactionResponse.errors[0].errorText}"
                };

            }
            return new TransactionResponse
            {
                Successful = false,
                Response = $"Error: {response.messages.message[0].code} {response.messages.message[0].text}"
            };
        }

        public class TransactionResponse
        {
            public bool Successful;
            public string Response;
        }
    }
}
