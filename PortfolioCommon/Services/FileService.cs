using Microsoft.AspNetCore.Http;
using PortfolioCommon.Services.Helpers;
using System.IO;

namespace PortfolioCommon.Services
{
    public abstract class FileService
    {
        protected static string SavePhoto(IFormFile formFile, string imageRootPath, string imageRootUrl)
        {
            ImageHelper.CheckIfPhotoIsValidImage(formFile.FileName);
            string photo = $"{imageRootUrl}{formFile.FileName}",
                physicalPhoto = Path.Combine(imageRootPath, formFile.FileName);
            using var stream = new FileStream(physicalPhoto, FileMode.Create);
            formFile.OpenReadStream().CopyTo(stream);
            return photo;
        }
    }
}
