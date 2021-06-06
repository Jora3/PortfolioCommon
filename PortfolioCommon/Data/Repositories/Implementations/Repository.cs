using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly PortfolioContext _portfolioContext;

        public Repository(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public virtual int Create(T entity)
        {
            if (entity == null) throw new Exception("L'entité est nulle.");
            _portfolioContext.Set<T>()
                .Add(entity);
            _portfolioContext.SaveChanges();
            return entity.Id;
        }

        public virtual void Delete(int id)
        {
            var entity = ReadOne(id);
            if (entity == null) return;
            _portfolioContext.Set<T>()
                .Remove(entity);
            _portfolioContext.SaveChanges();
        }

        public virtual void DeleteMany(Func<T, bool> conditions)
        {
            _portfolioContext.Set<T>()
                .RemoveRange(ReadMany(conditions));
            _portfolioContext.SaveChanges();
        }

        public virtual IList<T> ReadAll()
        {
            return _portfolioContext.Set<T>()
                .ToList();
        }

        public virtual IList<T> ReadMany(Func<T, bool> conditions)
        {
            if (conditions == null)
                return ReadAll();
            return _portfolioContext.Set<T>()
                .Where(conditions)
                .ToList();
        }

        public virtual T ReadOne(int id)
        {
            return _portfolioContext.Set<T>()
                .Find(id);
        }

        public virtual T ReadOne(Func<T, bool> conditions)
        {
            if (conditions == null)
                return ReadAll().FirstOrDefault();
            return _portfolioContext.Set<T>()
                .FirstOrDefault(conditions);
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new Exception("L'entité est nulle.");
            _portfolioContext.Set<T>()
                .Update(entity);
            _portfolioContext.SaveChanges();
        }
    }
}
