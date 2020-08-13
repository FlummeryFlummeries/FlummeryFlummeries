using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerce_App.Models.Services;
using ECommerce_App.Models.Interface;

namespace ECommerce_App.Pages.ImageUpload
{
    public class ImageUploadModel : PageModel
    {
        private readonly IImage _imageService;

        public ImageUploadModel(IImage imageService)
        {
            _imageService = imageService;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            _imageService.UploadImage();
        }
    }
}
