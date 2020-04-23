using ArticleExercise.Domain.Models;

namespace ArticleExercise.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void AddArticle(Article article, string categoryId);
    }
}