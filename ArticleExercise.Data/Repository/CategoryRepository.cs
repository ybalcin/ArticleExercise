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
    }
}