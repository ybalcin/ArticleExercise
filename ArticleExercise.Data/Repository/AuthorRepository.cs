using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;

namespace ArticleExercise.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}