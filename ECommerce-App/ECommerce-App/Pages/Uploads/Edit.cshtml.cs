using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Uploads
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private IImage _imageService;
        private IFlummeryInventory _flummery;

        [BindProperty]
        public ItemUploadViewModel Input { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string ImgUrl { get; set; }

        public EditModel(IImage imageService, IFlummeryInventory flummery)
        {
            _imageService = imageService;
            _flummery = flummery;
        }

        /// <summary>
        /// Get the specified flummeries information and display to the page, redirect to Products if it can't be found
        /// </summary>
        /// <param name="id">ID of flummery to edit</param>
        /// <returns>Page with the specified flummery info or redirection to Admin dash if it's not found</returns>
        public async Task<IActionResult> OnGet(int id)
        {
            Id = id;
            Flummery flum = await _flummery.GetFlummeryBy(id);
            if (flum != null)
            {
                Input = new ItemUploadViewModel
                {
                    Manufacturer = flum.Manufacturer,
                    Name = flum.Name,
                    Calories = flum.Calories,
                    Weight = flum.Weight,
                    Price = flum.Price,
                    Compliment = flum.Compliment,
                };
                ImgUrl = flum.ImageUrl;
                return Page();
            }
            return RedirectToPage("/Admin/Index");

        }

        /// <summary>
        /// Handling the updating of the current flummery and upload possible new image to Cloud
        /// </summary>
        /// <returns>Redirection to product view page for editted flummery or displays ModelState errors to form</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var flum = await UpdateFlum(Id);
                if (Input.ImageFile != null)
                {
                    string fileExt = Path.GetExtension(Input.ImageFile.FileName);
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        await Input.ImageFile.CopyToAsync(memStream);
                        byte[] imageData = memStream.ToArray();
                        string imageURI = await _imageService.UploadImage($"{Input.Name}{fileExt}", imageData, Input.ImageFile.ContentType, flum.Id);
                        await _imageService.UpdateStoreDbFor(flum.Id, imageURI);
                    }
                }
                return RedirectToPage("/ProductDetails/ProductDetails", new { Id });
            }
            ModelState.AddModelError("", "Something went wrong!");
            return Page();
        }

        /// <summary>
        /// Update the specified flummery in the database
        /// </summary>
        /// <param name="id">Id of flummery being updated</param>
        /// <returns>Updated flummery</returns>
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
            if(Input.ImageFile == null)
            {
                flum.ImageUrl = ImgUrl;
            }
            flum = await _flummery.UpdateFlummery(flum);
            return flum;
        }
    }
}