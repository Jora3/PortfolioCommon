using PortfolioCommon.Data.Entities;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Interfaces
{
    public interface ISkillService
    {
        IList<Skill> GetAll();
        void Add(string title, string width, int valueNow, int valueMin, int valueMax);
        Skill GetByTitle(string title);
        Skill GetById(int id);
        void Remove(int id);
        void Update(int id, string title, string width, int valueNow, int valueMin, int valueMax);
    }
}
