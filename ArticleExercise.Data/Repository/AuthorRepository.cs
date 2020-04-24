using System;
using System.Linq;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleExercise.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddArticle(string authorId, Article article)
        {
            var author = Find(authorId);
            article.ModifiedDate = DateTime.Now;
            author.Articles.Add(article);
            SaveChanges();
        }

        public override IQueryable<Author> Search(string searchText)
        {
            return DbSet.Where(f =>
                f.Title.Contains(searchText) ||
                f.FirstName.Contains(searchText) ||
                f.LastName.Contains(searchText));
        }
    }
}