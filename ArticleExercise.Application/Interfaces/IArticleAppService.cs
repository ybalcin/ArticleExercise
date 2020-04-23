using System.Collections.Generic;
using ArticleExercise.Application.InputModels;
using ArticleExercise.Application.ViewModels;

namespace ArticleExercise.Application.Interfaces
{
    public interface IArticleAppService : IAppService
    {
        IEnumerable<ArticleViewModel> GetAll();
        void Add(AddArticleToAuthorInputModel model);
        ArticleViewModel GetArticle(string id);
        void Like(string id);
        ArticleViewModel GetDetail(string id);
    }
}