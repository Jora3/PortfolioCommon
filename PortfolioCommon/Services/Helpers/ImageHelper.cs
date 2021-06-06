using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PortfolioCommon.Services.Helpers
{
    public static class ImageHelper
    {
        public static void CheckIfPhotoIsValidImage(string file)
        {
            string extension = Path.GetExtension(file).ToLower();
            if (extension == ".png" || extension == ".jpg"
                || extension == ".jpeg" || extension == ".gif"
                || extension == ".jfif") return;
            throw new Exception($"La photo n'est pas au format image valide. ({extension})");
        }
        public static string SavePhoto(IFormFile formFile, string imageRootPath, string imageRootUrl)
        {
            CheckIfPhotoIsValidImage(formFile.FileName);
            string photo = $"{imageRootUrl}{formFile.FileName}",
                physicalPhoto = Path.Combine(imageRootPath, formFile.FileName);
            using var stream = new FileStream(physicalPhoto, FileMode.Create);
            formFile.OpenReadStream().CopyTo(stream);
            return photo;
        }
    }
}
