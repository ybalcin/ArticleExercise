using ArticleExercise.Domain.Models;

namespace ArticleExercise.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        void AddArticle(string authorId, Article article);
    }
}