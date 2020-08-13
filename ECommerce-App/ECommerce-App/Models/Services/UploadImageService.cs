using ECommerce_App.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using ECommerce_App.Data;
using Azure.Storage.Blobs.Specialized;

namespace ECommerce_App.Models.Services
{
    public class UploadImageService : IImage
    {
        private IConfiguration Configuration { get; }

        private StoreDbContext _context;

        public UploadImageService(IConfiguration configuration, StoreDbContext context)
        {
            Configuration = configuration;
            _context = context;
        }

        public async Task UploadImage(IFormFile file)
        {
            string blobConnectionString = Configuration.GetConnectionString("AzureBlobConnection");
            BlobServiceClient blobServiceClient = new BlobServiceClient(blobConnectionString);
            string containerName = "ECommerce-App" + Guid.NewGuid().ToString();
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

            BlobClient blobClient = containerClient.GetBlobClient(file.FileName);
            var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream);

            var blobURL = blobClient.Uri.AbsoluteUri;

            throw new NotImplementedException();
        }
    }
}
