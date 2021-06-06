using Microsoft.AspNetCore.Http;
using PortfolioCommon.Data.Entities;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Interfaces
{
    public interface IWorkService
    {
        void UpdateItem(int id, int typeId, string projectName, string projectDescription, IFormFile formFile, string imageRootPath, string imageRootUrl);
        WorkItem GetItem(int id);
        void Remove(int id);
        void AddItem(int typeId, string projectName, string projectDescription, string pathPhoto);
        string SaveWorkItemPhoto(IFormFile photo, string imageRootPath, string imageRootUrl);
        WorkType GetTypeByCode(string code);
        WorkType GetTypeByLabel(string label);
        void UpdateType(int id, string code, string label, string description);
        void RemoveType(int id);
        WorkType GetType(int id);
        void AddType(string code, string label, string description);
        IList<WorkType> GetAllTypes();
        IList<WorkItem> GetAll();
    }
}
