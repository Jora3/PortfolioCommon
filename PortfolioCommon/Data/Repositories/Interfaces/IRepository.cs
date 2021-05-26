using PortfolioCommon.Data.Entities;
using System;
using System.Collections.Generic;

namespace PortfolioCommon.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        int Create(T entity);
        T ReadOne(int id);
        T ReadOne(Func<T, bool> conditions);
        IList<T> ReadAll();
        IList<T> ReadMany(Func<T, bool> conditions);
        void Update(T entity);
        void Delete(int id);
        void DeleteMany(Func<T, bool> conditions);
    }
}
