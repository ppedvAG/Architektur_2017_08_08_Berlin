using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}