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
using ECommerce_App.Models.ViewModels;

namespace ECommerce_App.Pages.ImageUpload
{
    [Authorize(Policy = "AdminOnly")]
    public class ImageUploadModel : PageModel
    {        
        private IImage _imageService;
        private IFlummeryInventory _flummery;

        [BindProperty]
        public ItemUploadViewModel Input { get; set; }

        public ImageUploadModel(IImage imageService, IFlummeryInventory flummery)
        {
            _imageService = imageService;
            _flummery = flummery;
        }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                var flum = await CreateFlum();
                string fileExt = Path.GetExtension(Input.ImageFile.FileName);
                if (Input.ImageFile != null)
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        await Input.ImageFile.CopyToAsync(memStream);
                        byte[] imageData = memStream.ToArray();
                        string imageURI = await _imageService.UploadImage($"{Input.Name}{fileExt}", imageData, Input.ImageFile.ContentType, flum.Id);
                        await _imageService.UpdateStoreDbFor(flum.Id, imageURI);
                    }
                }
            }
        }

        public async Task<Flummery> CreateFlum()
        {
            Flummery flum = new Flummery
            {
                Name = Input.Name,
                Manufacturer = Input.Manufacturer,
                Price = Input.Price,
                Calories = Input.Calories,
                Weight = Input.Weight,
                Compliment = Input.Compliment
            };
            flum = await _flummery.CreateFlummery(flum);
            return flum;
        }
    }
}
