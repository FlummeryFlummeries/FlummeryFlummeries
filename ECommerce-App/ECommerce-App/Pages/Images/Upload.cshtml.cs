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


namespace ECommerce_App.Pages.Images
{
    [Authorize(Policy = "AdminOnly")]
    public class UploadModel : PageModel
    {
        private IImage _imageService;

        private IFlummeryInventory _inventory;

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public string Name { get; set; }

        public string CurrentImgUrl { get; set; }

        public UploadModel(IImage imageService, IFlummeryInventory inventory)
        {
            _imageService = imageService;
            _inventory = inventory;
        }

        public async Task OnGet(int id)
        {
            var item = await _inventory.GetFlummeryBy(id);
            Name = item.Name;
            CurrentImgUrl = item.ImageUrl;
        }

        public async Task OnPost(int id)
        {
            var item = await _inventory.GetFlummeryBy(id);
            Name = item.Name;
            string fileExt = Path.GetExtension(ImageFile.FileName);
            if (ImageFile != null)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memStream);
                    Byte[] imageData = memStream.ToArray();
                    string imageURI = await _imageService.UploadImage($"{Name}{fileExt}", imageData, ImageFile.ContentType, id);
                    CurrentImgUrl = imageURI;
                    await _imageService.UpdateStoreDbFor(id, imageURI);
                }
            }
        }
    }
}
