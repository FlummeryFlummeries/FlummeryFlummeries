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
using Microsoft.EntityFrameworkCore;

namespace ECommerce_App.Models.Services
{
    public class UploadImageService : IImage
    {
        private IConfiguration _config { get; }

        private IFlummeryInventory _flummeryInventory;

        public CloudStorageAccount CloudStorageAccount { get; set; }

        public CloudBlobClient CloudBlobClient { get; set; }

        public UploadImageService(IConfiguration configuration, IFlummeryInventory flummeryInventory)
        {
            _config = configuration;
            _flummeryInventory = flummeryInventory;
            StorageCredentials storageCreds = new StorageCredentials(_config["AzureBlobAccountName"], _config["AzureBlobKey"]);
            CloudStorageAccount = new CloudStorageAccount(storageCreds, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Get the CloudBlobContainer in order to get/update images within it
        /// </summary>
        /// <param name="containerName">Name of the blob container</param>
        /// <returns>Task of completion of CloudBlobContainer object</returns>
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

        /// <summary>
        /// Get a specific blob by it's imageName from a specified blob container
        /// </summary>
        /// <param name="imageName">Name of the image to find in Blob Container</param>
        /// <param name="containerName">Name of the container to search</param>
        /// <returns>Task of completion of CloudBlob object extracted from the container</returns>
        public async Task<CloudBlob> GetBlobWith(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainerWith(containerName);
            CloudBlob cloudBlob = container.GetBlobReference(imageName);
            return cloudBlob;
        }

        /// <summary>
        /// Upload a new image to Cloud Storage by bringing in and adding it to the Blob Container
        /// </summary>
        /// <param name="imageFileName">Image file name to use as the key in Cloud Storage</param>
        /// <param name="imageData">Byte array representing the image data</param>
        /// <param name="contentType">Type of content that is being uploaded</param>
        /// <param name="flummeryId">Id of the flummery for which the image is being uploaded</param>
        /// <returns>Task of completion of URI string for the uploaded image</returns>
        public async Task<string> UploadImage(string imageFileName, byte[] imageData, string contentType, int flummeryId)
        {
            string containerName = _config["AppContainerName"];
            CloudBlobContainer container = await GetContainerWith(containerName);
            CloudBlockBlob blobRef = container.GetBlockBlobReference(imageFileName);
            blobRef.Properties.ContentType = contentType;
            await blobRef.UploadFromByteArrayAsync(imageData, 0, imageData.Length);
            return blobRef.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Add the imageURI to the flummery being updated
        /// </summary>
        /// <param name="flummeryId">Id of flummery to add image to</param>
        /// <param name="imageURI">Image URI to add to the flummery, stored in cloud storage</param>
        /// <returns>Task of completion of updated Flummery</returns>
        public async Task<Flummery> UpdateStoreDbFor(int flummeryId, string imageURI)
        {
            Flummery flummery = await _flummeryInventory.GetFlummeryBy(flummeryId);
            flummery.ImageUrl = imageURI;
            return await _flummeryInventory.UpdateFlummery(flummery);
        }
    }
}
