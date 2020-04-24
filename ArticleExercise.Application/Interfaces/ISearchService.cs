using ArticleExercise.Domain.QueryModels;

namespace ArticleExercise.Application.Interfaces
{
    public interface ISearchService
    {
        SearchQueryModel Search(string searchText);
    }
}