using System.Collections.Generic;
using ArticleExercise.Application.InputModels;
using ArticleExercise.Application.ViewModels;

namespace ArticleExercise.Application.Interfaces
{
    public interface IAuthorAppService : IAppService
    {
        AuthorViewModel Add(AuthorInputModel input);
        IEnumerable<AuthorViewModel> GetAll();
        AuthorViewModel GetAuthor(string id);
        ArticleViewModel AddArticle(AddArticleToAuthorInputModel input, string authorId);
        IEnumerable<ArticleViewModel> GetArticles(string id);
    }
}