﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Core.Models;
using ArticleExercise.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleExercise.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            SaveChanges();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> @where)
        {
            return _dbSet.Where(where);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Remove(string id)
        {
            var entity = _dbSet.Find(id);
            entity.IsDeleted = true;
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            SaveChanges();
        }

        public int SaveChanges()
        {
            _context.Dispose();
            return _context.SaveChanges();
        }
    }
}