using System;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;

namespace ArticleExercise.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddArticle(string authorId, Article article)
        {
            var author = Find(authorId);
            article.ModifiedDate = DateTime.Now;
            author.Articles.Add(article);
            SaveChanges();
        }
    }
}