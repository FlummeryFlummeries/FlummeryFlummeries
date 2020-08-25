using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
    [BindProperties]
    public class PasswordChangeViewModel
    {
        [Required]
        [Display(Name = "Enter Current Password")]
        public string ConfirmPassword { get; set; }      
        
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
