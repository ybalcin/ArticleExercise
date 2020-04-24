using System;
using System.Linq;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;

namespace ArticleExercise.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddArticle(Article article, string categoryId)
        {
            var category = Find(categoryId);
            article.ModifiedDate = DateTime.Now;
            category.Articles.Add(article);
            SaveChanges();
        }

        public override IQueryable<Category> Search(string searchText)
        {
            return DbSet.Where(f => f.Name.Contains(searchText));
        }
    }
}