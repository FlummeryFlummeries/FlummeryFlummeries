using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Emails
{
    public class EmailItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("imgSrc")]
        public string ImgSrc { get; set; }

        [JsonProperty("qty")]
        public int Qty { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }       
        
        [JsonProperty("itemPrice")]
        public decimal ItemPrice { get; set; }

        [JsonProperty("itemTotal")]
        public decimal ItemTotal { get; set; }
    }
}
