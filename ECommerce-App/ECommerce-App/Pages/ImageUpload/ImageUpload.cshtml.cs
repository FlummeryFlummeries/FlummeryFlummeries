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
using ECommerce_App.Models.ViewModels;
using Microsoft.Azure.Storage.Blob;
using ECommerce_App.Models;
using System.Runtime.InteropServices;

namespace ECommerce_App.Pages.ImageUpload
{
    public class ImageUploadModel : PageModel
    {
        private IConfiguration _config;
        
        private IImage _imageService;

        private IFlummeryInventory _flummeryInventory;

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public ImageUploadModel(IConfiguration config, IImage imageService, IFlummeryInventory flummeryInventory)
        {
            _config = config;
            _imageService = imageService;
            _flummeryInventory = flummeryInventory;
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
                    await _imageService.UploadImage(_config["AppContainerName"], $"{Name}{fileExt}", imageData, ImageFile.ContentType, ProductId);
                }
                CloudBlob imageBlob = await _imageService.GetBlobWith($"{Name}{fileExt}", _config["AppContainerName"]);
                string imageURI = imageBlob.Uri.AbsoluteUri;
                await UpdateStoreDbFor(ProductId, imageURI);
            }
        }

        public async Task UpdateStoreDbFor(int flummeryId, string imageURI)
        {
            Flummery flummery = await _flummeryInventory.GetFlummeryByWithoutVM(flummeryId);
            flummery.ImageUrl = imageURI;
            Flummery updatedFlummery = await _flummeryInventory.UpdateFlummeryWithoutVM(flummery);

            //FlummeryVM flummeryVM = await _flummeryInventory.GetFlummeryBy(flummeryId);
            //flummeryVM.ImageUrl = imageURI;
            //FlummeryVM updatedFlummeryVM = await _flummeryInventory.UpdateFlummery(flummeryVM);
        }
    }
}
