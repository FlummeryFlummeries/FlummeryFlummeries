using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Emails
{
    public class RegistrationTemplateData
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("displayItem")]
        public List<EmailItem> DisplayItems { get; set; }
    }
}
