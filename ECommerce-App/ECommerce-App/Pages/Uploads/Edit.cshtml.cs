using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Uploads
{
    public class EditModel : PageModel
    {
        private IImage _imageService;
        private IFlummeryInventory _flummery;

        [BindProperty]
        public ItemUploadViewModel Input { get; set; }

        public EditModel(IImage imageService, IFlummeryInventory flummery)
        {
            _imageService = imageService;
            _flummery = flummery;
        }
        public async void OnGet(int id)
        {
            Flummery flum = await _flummery.GetFlummeryBy(id);
            if(flum != null)
            {
                Input = new ItemUploadViewModel
                {
                    Manufacturer = flum.Manufacturer,
                    Name = flum.Name,
                    Calories = flum.Calories,
                    Weight = flum.Weight,
                    Price = flum.Price,
                    Compliment = flum.Compliment,
                    ImgUrl = flum.ImageUrl
                };
            }
        }

        public async Task OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var flum = await UpdateFlum(id);
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

        public async Task<Flummery> UpdateFlum(int id)
        {
            Flummery flum = new Flummery
            {
                Id = id,
                Name = Input.Name,
                Manufacturer = Input.Manufacturer,
                Price = Input.Price,
                Calories = Input.Calories,
                Weight = Input.Weight,
                Compliment = Input.Compliment
            };
            flum = await _flummery.UpdateFlummery(flum);
            return flum;
        }
    }
}