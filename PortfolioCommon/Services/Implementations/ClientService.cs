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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client GetByName(string name)
        {
            return _clientRepository.ReadOne(c => c.Name.ToLower().Equals(name.ToLower().Trim()));
        }

        public void Update(int id, string name, IFormFile formFile, string imageRootPath, string imageRootUrl)
        {
            CheckName(name);
            var client = Get(id);
            if (client != null)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    string oldLogo = Path.GetFileName(client.Logo);
                    client.Logo = SaveLogo(formFile, imageRootPath, imageRootUrl);
                    if (oldLogo != formFile.FileName)
                    {
                        if (File.Exists(oldLogo))
                            File.Delete(oldLogo);
                    }
                }
                if (client.Name.ToLower() != name.ToLower().Trim())
                {
                    if (GetByName(name) != null)
                        throw new Exception("Un client ayant le même nom existe déjà.");
                }
                client.Name = name;
                _clientRepository.Update(client);
            }
            else
                throw new Exception("Aucun client ne correspond à l'ID renseigné.");
        }

        public Client Get(int id)
        {
            return _clientRepository.ReadOne(id);
        }

        public void Remove(int id)
        {
            _clientRepository.Delete(id);
        }

        public void Add(string name, string logo)
        {
            CheckName(name);
            ImageHelper.CheckIfPhotoIsValidImage(Path.GetFileName(logo));
            _clientRepository.Create(new Client
            {
                Name = name.Trim(),
                Logo = logo
            });
        }

        public IList<Client> GetAll()
        {
            return _clientRepository.ReadAll();
        }

        public string SaveLogo(IFormFile formFile, string imageRootPath, string imageRootUrl)
        {
            if (formFile == null || formFile.Length <= 0)
                throw new Exception("Le logo du client est vide ou n'a pas été renseigné.");
            return ImageHelper.SavePhoto(formFile, imageRootPath, imageRootUrl);
        }

        private static void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new Exception("Le nom du client est vide ou n'a pas été renseigné.");
        }
    }
}
