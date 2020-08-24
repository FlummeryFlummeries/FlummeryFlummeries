using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;

namespace ECommerce_App.Models.Interface
{
    public interface IImage
    {
        /// <summary>
        /// Get the CloudBlobContainer in order to get/update images within it
        /// </summary>
        /// <param name="containerName">Name of the blob container</param>
        /// <returns>Task of completion of CloudBlobContainer object</returns>
        Task<CloudBlobContainer> GetContainerWith(string containerName);

        /// <summary>
        /// Get a specific blob by it's imageName from a specified blob container
        /// </summary>
        /// <param name="imageName">Name of the image to find in Blob Container</param>
        /// <param name="containerName">Name of the container to search</param>
        /// <returns>Task of completion of CloudBlob object extracted from the container</returns>
        Task<CloudBlob> GetBlobWith(string imageName, string containerName);

        /// <summary>
        /// Upload a new image to Cloud Storage by bringing in and adding it to the Blob Container
        /// </summary>
        /// <param name="imageFileName">Image file name to use as the key in Cloud Storage</param>
        /// <param name="imageData">Byte array representing the image data</param>
        /// <param name="contentType">Type of content that is being uploaded</param>
        /// <param name="flummeryId">Id of the flummery for which the image is being uploaded</param>
        /// <returns>Task of completion of URI string for the uploaded image</returns>
        Task<string> UploadImage(string imageFileName, byte[] imageData, string contentType, int flummeryId);

        /// <summary>
        /// Add the imageURI to the flummery being updated
        /// </summary>
        /// <param name="flummeryId">Id of flummery to add image to</param>
        /// <param name="imageURI">Image URI to add to the flummery, stored in cloud storage</param>
        /// <returns>Task of completion of updated Flummery</returns>
        Task<Flummery> UpdateStoreDbFor(int flummeryId, string imageURI);
    }
}
