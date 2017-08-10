using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> Entries { get; }

        public Repository(TContext context)
        {
            Context = context;
            Entries = context.Set<TEntity>();
        }

        public void Add(TEntity entity) => Entries.Add(entity);
        public void AddRange(IEnumerable<TEntity> entities) => Entries.AddRange(entities);
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => Entries.FirstOrDefault(predicate);
        public TEntity Get(int id) => Entries.Find(id);
        public IEnumerable<TEntity> GetAll() => Entries.ToList();
        public void Remove(TEntity entity) => Entries.Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities) => Entries.RemoveRange(Entries);
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => Entries.SingleOrDefault(predicate);
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate) => Entries.Where(predicate).ToList();
    }
}
