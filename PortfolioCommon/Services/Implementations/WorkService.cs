using Microsoft.AspNetCore.Http;
using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Repositories.Interfaces;
using PortfolioCommon.Services.Helpers;
using PortfolioCommon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace PortfolioCommon.Services.Implementations
{
    public class WorkService : IWorkService
    {
        private readonly IWorkItemRepository _workItemRepository;
        private readonly IWorkTypeRepository _workTypeRepository;

        public WorkService(IWorkItemRepository workItemRepository, IWorkTypeRepository workTypeRepository)
        {
            _workItemRepository = workItemRepository;
            _workTypeRepository = workTypeRepository;
        }

        #region PUBLIC METHOD
        public WorkItem GetItemByProjectName(string projectName)
        {
            return _workItemRepository.ReadOne(w => w.ProjectName.ToLower().Equals(projectName.ToLower()));
        }

        public void UpdateItem(int id, int typeId, string projectName, string projectDescription, IFormFile formFile, string imageRootPath, string imageRootUrl)
        {
            CheckProjectName(projectName);
            var work = GetItem(id);
            if (work != null)
            {
                string oldPhoto = Path.GetFileName(work.PathPhoto);
                if (formFile != null)
                {
                    work.PathPhoto = SaveWorkItemPhoto(formFile, imageRootPath, imageRootUrl);
                    if (formFile.FileName != oldPhoto)
                    {
                        string oldPhotoPath = Path.Combine(imageRootPath, oldPhoto);
                        if (File.Exists(oldPhotoPath))
                            File.Delete(oldPhotoPath);
                    }
                }
                if (!work.ProjectName.ToLower().Equals(projectName))
                {
                    if (GetItemByProjectName(projectName) != null)
                        throw new Exception("Le nom de projet renseigné est déjà pris.");
                }
                var type = CheckType(typeId);
                work.WorkType = type;
                work.ProjectName = projectName;
                work.ProjectDescription = projectDescription;
                _workItemRepository.Update(work);
            }
            else
                throw new Exception("Aucun projet ne correspond à l'ID renseigné.");
        }

        public WorkItem GetItem(int id)
        {
            return _workItemRepository.ReadOne(id);
        }

        public void AddType(string code, string label, string description)
        {
            CheckTypeCode(code);
            CheckTypeLabel(label);
            _workTypeRepository.Create(new WorkType
            {
                Code = code.Trim(),
                Label = label.Trim(),
                Description = description
            });
        }

        public IList<WorkItem> GetAll()
        {
            return _workItemRepository.ReadAll();
        }

        public IList<WorkType> GetAllTypes()
        {
            return _workTypeRepository.ReadAll();
        }

        public WorkType GetType(int id)
        {
            return _workTypeRepository.ReadOne(id);
        }

        public WorkType GetTypeByCode(string code)
        {
            return _workTypeRepository.ReadOne(t => t.Code.ToLower().Equals(code.ToLower()));
        }

        public WorkType GetTypeByLabel(string label)
        {
            return _workTypeRepository.ReadOne(t => t.Label.ToLower().Equals(label.ToLower()));
        }

        public void RemoveType(int id)
        {
            var works = _workItemRepository.ReadMany(w => w.WorkType.Id == id);
            foreach (var work in works)
                _workItemRepository.Delete(work.Id);
            _workTypeRepository.Delete(id);
        }

        public void UpdateType(int id, string code, string label, string description)
        {
            CheckTypeCode(code);
            CheckTypeLabel(label);

            code = code.Trim();
            label = label.Trim();

            var workType = GetType(id);
            if (workType != null)
            {
                if (workType.Code.ToLower() != code.ToLower())
                {
                    if (GetTypeByCode(code) != null)
                        throw new Exception("Le code du type de travail renseigné est déjà utilisé.");
                }
                if (workType.Label.ToLower() != label.ToLower())
                {
                    if (GetTypeByLabel(label) != null)
                        throw new Exception("Le libellé du type de travail renseigné est déjà utilisé.");
                }
                workType.Code = code;
                workType.Label = label;
                workType.Description = description;
                _workTypeRepository.Update(workType);
            }
            else
                throw new Exception("Aucun type de travail ne correspond à l'ID renseigné.");
        }

        public string SaveWorkItemPhoto(IFormFile photo, string imageRootPath, string imageRootUrl)
        {
            if (photo == null || photo.Length <= 0)
                throw new Exception("La photo représentant le projet est vide ou n'a pas été renseignée.");
            return ImageHelper.SavePhoto(photo, imageRootPath, imageRootUrl);
        }

        public void AddItem(int typeId, string projectName, string projectDescription, string pathPhoto)
        {
            CheckProjectName(projectName);
            CheckProjectPhoto(pathPhoto);

            var type = CheckType(typeId);

            ImageHelper.CheckIfPhotoIsValidImage(Path.GetExtension(pathPhoto));

            _workItemRepository.Create(new WorkItem
            {
                WorkType = type,
                ProjectName = projectName.Trim(),
                ProjectDescription = projectDescription,
                PathPhoto = pathPhoto
            });
        }

        public void Remove(int id)
        {
            _workItemRepository.Delete(id);
        }
        #endregion

        #region PRIVATE METHOD
        private WorkType CheckType(int typeId)
        {
            var type = GetType(typeId);
            if (type == null)
                throw new Exception("Aucun type de projet ne correspond à l'ID renseigné.");
            return type;
        }

        private static void CheckProjectPhoto(string pathPhoto)
        {
            if (string.IsNullOrEmpty(pathPhoto) || string.IsNullOrWhiteSpace(pathPhoto))
                throw new Exception("La photo du projet est vide ou n'a pas été renseignée.");
        }

        private static void CheckProjectName(string projectName)
        {
            if (string.IsNullOrEmpty(projectName) || string.IsNullOrWhiteSpace(projectName))
                throw new Exception("Le nom du projet est vide ou n'a pas été renseigné.");
        }

        private static void CheckTypeLabel(string label)
        {
            if (string.IsNullOrEmpty(label) || string.IsNullOrWhiteSpace(label))
                throw new Exception("Le libellé du type de travail est vide ou n'a pas été renseigné.");
        }

        private static void CheckTypeCode(string code)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrWhiteSpace(code))
                throw new Exception("Le code du type de travail est vide ou n'a pas été renseigné.");
        }
        #endregion
    }
}
