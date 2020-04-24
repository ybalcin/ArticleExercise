using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Core.Models;
using ArticleExercise.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleExercise.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TEntity Add(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            DbSet.Add(entity);
            SaveChanges();
            return entity;
        }

        public TEntity Find(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await DbSet.FindAsync(keyValues);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> @where)
        {
            return DbSet.Where(where);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void Remove(string id)
        {
            var entity = DbSet.Find(id);
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            DbSet.Update(entity);
            SaveChanges();
        }

        public abstract IQueryable<TEntity> Search(string searchText);

        public int SaveChanges()
        {
            var saveChanges = Context.SaveChanges();
            Context.Dispose();
            return saveChanges;
        }
    }
}