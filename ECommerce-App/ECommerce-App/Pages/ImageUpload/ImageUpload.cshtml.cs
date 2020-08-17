using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerce_App.Models.Services;
using ECommerce_App.Models.Interface;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Storage.Blob;
using ECommerce_App.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce_App.Pages.ImageUpload
{
    [Authorize(Policy = "AdminOnly")]
    public class ImageUploadModel : PageModel
    {
        private IConfiguration _config;
        
        private IImage _imageService;

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public ImageUploadModel(IConfiguration config, IImage imageService)
        {
            _config = config;
            _imageService = imageService;
        }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            string fileExt = Path.GetExtension(ImageFile.FileName);
            if (ImageFile != null)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memStream);
                    Byte[] imageData = memStream.ToArray();
                    string imageURI = await _imageService.UploadImage(_config["AppContainerName"], $"{Name}{fileExt}", imageData, ImageFile.ContentType, ProductId);
                    await _imageService.UpdateStoreDbFor(ProductId, imageURI);
                }
            }
        }
    }
}
