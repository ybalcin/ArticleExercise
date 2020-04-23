using ArticleExercise.Domain.Models;

namespace ArticleExercise.Domain.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        void Like(string id);
        Article GetDetail(string id);
    }
}