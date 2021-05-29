using Microsoft.AspNetCore.Http;
using PortfolioCommon.Data.Entities;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Interfaces
{
    public interface IReferenceItemService
    {
        void Remove(int id);
        void Update(int id, string text, string referencerName, string referencerFunction, IFormFile formFile, string imageRootPath, string imageRootUrl);
        ReferenceItem GetById(int id);
        string SaveReferencerPhoto(IFormFile formFile, string imageRootPath, string imageRootUrl);
        void Add(string text, string referencerName, string referencerFunction, string referencerPhoto);
        IList<ReferenceItem> GetAll();
    }
}
