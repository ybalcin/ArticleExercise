using System;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;

namespace ArticleExercise.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddArticle(Article article, string categoryId)
        {
            var category = Find(categoryId);
            article.ModifiedDate = DateTime.Now;
            category.Articles.Add(article);
            SaveChanges();
        }
    }
}