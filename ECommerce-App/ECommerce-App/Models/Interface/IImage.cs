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
        Task<CloudBlobContainer> GetContainerWith(string containerName);

        Task<CloudBlob> GetBlobWith(string imageName, string containerName);

        Task<string> UploadImage(string imageFileName, byte[] imageData, string contentType, int flummeryId);

        Task<Flummery> UpdateStoreDbFor(int flummeryId, string imageURI);
    }
}
