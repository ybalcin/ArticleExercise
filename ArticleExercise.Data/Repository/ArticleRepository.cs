using System;
using System.Linq;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleExercise.Data.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Like(string id)
        {
            var article = Find(id);
            article.Like += 1;
            Update(article);
        }

        public Article GetWithAuthorAndCategory(string id)
        {
            return Context.Articles.Where(f => f.Id == id)
                .Include(i => i.Author)
                .Include(i => i.Category)
                .FirstOrDefault();
        }

        public override IQueryable<Article> Search(string searchText)
        {
            return DbSet.Where(f =>
                f.Detail.Contains(searchText) ||
                f.Title.Contains(searchText) ||
                f.Topic.Contains(searchText));
        }
    }
}