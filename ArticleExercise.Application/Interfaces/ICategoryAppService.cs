using System.Collections.Generic;
using ArticleExercise.Application.InputModels;
using ArticleExercise.Application.ViewModels;

namespace ArticleExercise.Application.Interfaces
{
    public interface ICategoryAppService : IAppService
    {
        CategoryViewModel AddCategory(CategoryInputModel input);
        IEnumerable<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(string id);
        ArticleViewModel AddArticle(AddArticleToCategoryInputModel article, string categoryId);
        IEnumerable<ArticleViewModel> GetArticles(string categoryId);
    }
}