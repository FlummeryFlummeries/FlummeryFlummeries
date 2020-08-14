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
using System.IO;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using ECommerce_App.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_App.Models.Services
{
    public class UploadImageService : IImage
    {
        private IConfiguration _config { get; }

        //private IFlummeryInventory _flummeryInventory;

        //private StoreDbContext _dbContext;

        public CloudStorageAccount CloudStorageAccount { get; set; }

        public CloudBlobClient CloudBlobClient { get; set; }

        public UploadImageService(IConfiguration configuration)
        {
            _config = configuration;
            //_flummeryInventory = flummeryInventory;
            //_dbContext = dbContext;
            StorageCredentials storageCreds = new StorageCredentials(_config["AzureBlobAccountName"], _config["AzureBlobKey"]);
            CloudStorageAccount = new CloudStorageAccount(storageCreds, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        public async Task<CloudBlobContainer> GetContainerWith(string containerName)
        { 
            CloudBlobContainer cloudBlobCtn = CloudBlobClient.GetContainerReference(containerName.ToLower());
            await cloudBlobCtn.CreateIfNotExistsAsync();
            await cloudBlobCtn.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            return cloudBlobCtn;
        }

        public async Task<CloudBlob> GetBlobWith(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainerWith(containerName);
            CloudBlob cloudBlob = container.GetBlobReference(imageName);
            return cloudBlob;
        }

        public async Task<string> UploadImage(string containerName, string imageFileName, byte[] imageData, string contentType, int flummeryId)
        {
            CloudBlobContainer container = await GetContainerWith(containerName);
            CloudBlockBlob blobRef = container.GetBlockBlobReference(imageFileName);
            blobRef.Properties.ContentType = contentType;
            await blobRef.UploadFromByteArrayAsync(imageData, 0, imageData.Length);
            return blobRef.Uri.AbsoluteUri;
        }

        //public async Task UpdateStoreDbFor(int flummeryId, string imageURI)
        //{
        //    Flummery flummery = await _dbContext.Flummery.FindAsync(flummeryId);
        //    flummery.ImageUrl = imageURI;
        //    _dbContext.Entry(flummery).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();

        //    //FlummeryVM flummeryVM = await _flummeryInventory.GetFlummeryBy(flummeryId);
        //    //flummeryVM.ImageUrl = imageURI;
        //    //FlummeryVM updatedFlummeryVM = await _flummeryInventory.UpdateFlummery(flummeryVM);
        //}
    }
}
