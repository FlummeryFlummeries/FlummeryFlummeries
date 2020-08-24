using ECommerce_App.Models.Emails;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services.Emails
{
    public class ReceiptTemplateData
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("cartItem")]
        public List<EmailItem> CartItems { get; set; }
    }
}
