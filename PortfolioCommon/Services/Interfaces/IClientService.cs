using Microsoft.AspNetCore.Http;
using PortfolioCommon.Data.Entities;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Interfaces
{
    public interface IClientService
    {
        Client GetByName(string name);
        void Update(int id, string name, IFormFile formFile, string imageRootPath, string imageRootUrl);
        Client Get(int id);
        void Remove(int id);
        void Add(string name, string logo);
        string SaveLogo(IFormFile formFile, string imageRootPath, string imageRootUrl);
        IList<Client> GetAll();
    }
}
