using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.ViewModels
{
    public class ItemUploadViewModel
    {
        [BindProperty]
        public string Manufacturer { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int Calories { get; set; }     
   
        [BindProperty]
        public decimal Weight { get; set; }

        [BindProperty]
        public decimal Price { get; set; }

        [BindProperty]
        public string Compliment { get; set; }  
        
        [BindProperty]
        public string ImgUrl { get; set; }

        [BindProperty]
        [Display(Name = "Image File")]
        public IFormFile ImageFile { get; set; }
    }
}
