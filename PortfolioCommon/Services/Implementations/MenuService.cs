using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Repositories.Interfaces;
using PortfolioCommon.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public void Add(string label, string href)
        {
            if (string.IsNullOrEmpty(label) || string.IsNullOrWhiteSpace(label))
                throw new Exception("Le libellé du menu est vide ou n'a pas été renseigné.");
            if (string.IsNullOrEmpty(href) || string.IsNullOrWhiteSpace(href))
                throw new Exception("L'attribut href du menu est vide ou n'a pas été renseigné.");

            CheckExistenceMenuByHref(href);
            CheckExistenceMenuByLabel(label);

            var menu = new Menu
            {
                Label = label,
                Href = href.ToLower()
            };
            _menuRepository.Create(menu);
        }

        public IList<Menu> GetAll()
        {
            return _menuRepository.ReadAll();
        }

        public Menu GetByHref(string href)
        {
            return _menuRepository.ReadOne(m => m.Href.ToLower().Equals(href.ToLower()));
        }

        public Menu GetById(int id)
        {
            return _menuRepository.ReadOne(id);
        }

        public Menu GetByLabel(string label)
        {
            return _menuRepository.ReadOne(m => m.Label.ToLower().Equals(label.ToLower()));
        }

        public void Remove(int id)
        {
            _menuRepository.Delete(id);
        }

        public void Update(int id, string label, string href)
        {
            var menu = GetById(id);
            if (menu != null)
            {
                if (menu.Label.ToLower() != label.ToLower())
                    CheckExistenceMenuByLabel(label);
                if (menu.Href.ToLower() != href.ToLower())
                    CheckExistenceMenuByHref(href);

                menu.Label = label;
                menu.Href = href.ToLower();

                _menuRepository.Update(menu);
            }
            else
                throw new Exception("Aucun menu ne correspond à l'ID renseigné.");
        }

        private void CheckExistenceMenuByHref(string href)
        {
            var byHref = GetByHref(href);
            if (byHref != null)
                throw new Exception("Un menu avec cet attribut href existe déjà.");
        }

        private void CheckExistenceMenuByLabel(string label)
        {
            var byLabel = GetByLabel(label);
            if (byLabel != null)
                throw new Exception("Un menu avec ce libellé existe déjà.");
        }
    }
}
