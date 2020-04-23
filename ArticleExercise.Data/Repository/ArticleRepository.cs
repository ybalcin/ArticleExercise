using System.Linq;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleExercise.Data.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Like(string id)
        {
            var article = Find(id);
            article.Like += 1;
            Update(article);
        }

        public Article GetDetail(string id)
        {
            return _context.Articles.Where(f => f.Id == id)
                .Include(i => i.Author)
                .Include(i => i.Category)
                .FirstOrDefault();
        }
    }
}