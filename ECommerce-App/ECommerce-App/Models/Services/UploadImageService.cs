using ECommerce_App.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace ECommerce_App.Models.Services
{
    public class UploadImageService : IImage
    {
        public IConfiguration Configuration { get; }

        public UploadImageService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task UploadImage()
        {
            string blobCS = Configuration.GetConnectionString("AzureBlobConnection");
            throw new NotImplementedException();
        }
    }
}
