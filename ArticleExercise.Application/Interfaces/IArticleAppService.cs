using System.Collections.Generic;
using ArticleExercise.Application.ViewModels;

namespace ArticleExercise.Application.Interfaces
{
    public interface IArticleAppService : IAppService
    {
        IEnumerable<ArticleViewModel> GetAll();
        void Add(ArticleViewModel model);
    }
}