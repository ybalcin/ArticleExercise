using System.Collections.Generic;
using ArticleExercise.Application.ViewModels;

namespace ArticleExercise.Application.Interfaces
{
    public interface ICategoryAppService : IAppService
    {
        void AddCategory(string name);
        IEnumerable<CategoryViewModel> GetCategories();
    }
}