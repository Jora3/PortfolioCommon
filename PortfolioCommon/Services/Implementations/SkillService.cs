using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Repositories.Interfaces;
using PortfolioCommon.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public void Add(string title, string width, int valueNow, int valueMin, int valueMax)
        {
            CheckTitle(title);
            CheckWidth(width);
            CheckExistenceByTitle(title);
            CheckValue(valueNow);
            CheckValue(valueMin);
            CheckValue(valueMax);
            _skillRepository.Create(new Skill
            {
                Title = title,
                Width = width,
                ValueNow = valueNow,
                ValueMin = valueMin,
                ValueMax = valueMax
            });
        }

        public IList<Skill> GetAll()
        {
            return _skillRepository.ReadAll();
        }

        public Skill GetById(int id)
        {
            return _skillRepository.ReadOne(id);
        }

        public Skill GetByTitle(string title)
        {
            return _skillRepository.ReadOne(s => s.Title.ToLower().Equals(title.ToLower()));
        }

        public void Remove(int id)
        {
            _skillRepository.Delete(id);
        }

        public void Update(int id, string title, string width, int valueNow, int valueMin, int valueMax)
        {
            CheckTitle(title);
            CheckWidth(width);

            var skill = GetById(id);
            if (skill != null)
            {
                if (skill.Title.ToLower() != title.ToLower())
                    CheckExistenceByTitle(title);

                CheckValue(valueNow);
                CheckValue(valueMin);
                CheckValue(valueMax);

                skill.Title = title;
                skill.Width = width;
                skill.ValueNow = valueNow;
                skill.ValueMin = valueMin;
                skill.ValueMax = valueMax;

                _skillRepository.Update(skill);
            }
            else
                throw new Exception("Aucune compétence ne correspond à l'ID renseigné.");
        }

        private static void CheckWidth(string width)
        {
            if (string.IsNullOrEmpty(width) || string.IsNullOrWhiteSpace(width))
                throw new Exception("La largeur de la barre de compétence est vide ou n'a pas été renseignée.");
        }

        private static void CheckTitle(string title)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                throw new Exception("L'intitulé de la compétence est vide ou n'a pas été renseigné.");
        }

        private static void CheckValue(int value)
        {
            if (value < 0 || value > 100)
                throw new Exception("La valeur doit être comprise entre 0 et 100.");
        }

        private void CheckExistenceByTitle(string title)
        {
            var skill = GetByTitle(title);
            if (skill != null)
                throw new Exception("Une compétence avec le même intitulé existe déjà.");
        }
    }
}
