using PortfolioCommon.Data.Entities;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Interfaces
{
    public interface IMenuService
    {
        IList<Menu> GetAll();
        void Add(string label, string href);
        void Remove(int id);
        Menu GetById(int id);
        void Update(int id, string label, string href);
        Menu GetByLabel(string label);
        Menu GetByHref(string href);
    }
}
