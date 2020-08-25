using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
    public class AccountInfoViewModel
    {
        [BindProperty]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [BindProperty]
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
