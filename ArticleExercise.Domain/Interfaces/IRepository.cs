using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArticleExercise.Domain.Core.Models;

namespace ArticleExercise.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity entity);
        TEntity Find(params object[] keyValues);
        Task<TEntity> FindAsync(params object[] keyValues);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> GetAll();
        void Remove(string id);
        void Update(TEntity entity);
        IQueryable<TEntity> Search(string searchText);
        int SaveChanges();
    }
}