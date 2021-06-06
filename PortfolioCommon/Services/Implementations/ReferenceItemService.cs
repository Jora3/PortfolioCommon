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
    public class ReferenceItemService : FileService, IReferenceItemService
    {
        private readonly IReferenceItemRepository _referenceItemRepository;

        public ReferenceItemService(IReferenceItemRepository referenceItemRepository)
        {
            _referenceItemRepository = referenceItemRepository;
        }

        public void Add(string text, string referencerName, string referencerFunction, string referencerPhoto)
        {
            CheckReferencerName(referencerName);
            CheckText(text);
            _referenceItemRepository.Create(new ReferenceItem
            {
                Text = text,
                ReferencerName = referencerName,
                ReferencerFunction = referencerFunction,
                ReferencerPhoto = referencerPhoto
            });
        }

        public IList<ReferenceItem> GetAll()
        {
            return _referenceItemRepository.ReadAll();
        }

        public ReferenceItem GetById(int id)
        {
            return _referenceItemRepository.ReadOne(id);
        }

        public string SaveReferencerPhoto(IFormFile formFile, string imageRootPath, string imageRootUrl)
        {
            if (formFile == null || formFile.Length <= 0)
                return null;
            return SavePhoto(formFile, imageRootPath, imageRootUrl);
        }

        public void Update(int id, string text, string referencerName, string referencerFunction, IFormFile formFile, string imageRootPath, string imageRootUrl)
        {
            CheckReferencerName(referencerName);
            CheckText(text);
            var reference = GetById(id);
            if (reference != null)
            {
                string oldReferencerPhotoFilename = Path.GetFileName(reference.ReferencerPhoto);
                if (formFile != null)
                {
                    reference.ReferencerPhoto = SaveReferencerPhoto(formFile, imageRootPath, imageRootUrl);
                    if (formFile.FileName != oldReferencerPhotoFilename)
                    {
                        string oldReferencerPhoto = Path.Combine(imageRootPath, oldReferencerPhotoFilename);
                        if (File.Exists(oldReferencerPhoto))
                            File.Delete(oldReferencerPhoto);
                    }
                }
                reference.Text = text;
                reference.ReferencerName = referencerName;
                reference.ReferencerFunction = referencerFunction;
                _referenceItemRepository.Update(reference);
            }
            else
                throw new Exception("Aucune référence ne correspond à l'ID renseigné.");
        }

        private static void CheckReferencerName(string referencerName)
        {
            if (string.IsNullOrEmpty(referencerName) || string.IsNullOrWhiteSpace(referencerName))
                throw new Exception("Le nom du référenceur est vide ou n'a pas été renseigné.");
        }

        private static void CheckText(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                throw new Exception("Le commentaire du référenceur est vide ou n'a pas été renseigné.");
        }

        public void Remove(int id)
        {
            _referenceItemRepository.Delete(id);
        }
    }
}
