using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECommerce_App.Models.Interface
{
    public interface IImage
    {
        Task UploadImage(IFormFile file);
    }
}
