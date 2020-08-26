using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
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
        
        [Required]
        public bool SaveBillingAddress { get; set; }

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
