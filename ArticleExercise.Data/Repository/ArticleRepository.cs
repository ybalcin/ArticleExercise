using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;

namespace ArticleExercise.Data.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}