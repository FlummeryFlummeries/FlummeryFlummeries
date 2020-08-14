using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using ECommerce_App.Models.ViewModels;

namespace ECommerce_App.Models.Interface
{
    public interface IImage
    {
        Task<CloudBlobContainer> GetContainerWith(string containerName);

        Task<CloudBlob> GetBlobWith(string imageName, string containerName);

        Task<string> UploadImage(string containerName, string imageFileName, byte[] imageData, string contentType, int flummeryId);

        //Task UpdateStoreDbFor(int flummeryId, string imageURI);
    }
}
