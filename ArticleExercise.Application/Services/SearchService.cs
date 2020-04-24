using ArticleExercise.Application.Interfaces;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;
using ArticleExercise.Domain.QueryModels;

namespace ArticleExercise.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SearchService(IArticleRepository articleRepository, IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public SearchQueryModel Search(string searchText)
        {
            var articles = _articleRepository.Search(searchText);
            var authors = _authorRepository.Search(searchText);
            var categories = _categoryRepository.Search(searchText);

            var articleSearchContent = new SearchContent()
            {
                Module = nameof(Article),
                Data = articles
            };
            var authorSearchContent = new SearchContent()
            {
                Module = nameof(Author),
                Data = authors
            };
            var categorySearchContent = new SearchContent()
            {
                Module = nameof(Category),
                Data = categories
            };

            var searchQueryModel = new SearchQueryModel() {SearchText = searchText};
            searchQueryModel.Contents.Add(articleSearchContent);
            searchQueryModel.Contents.Add(authorSearchContent);
            searchQueryModel.Contents.Add(categorySearchContent);

            return searchQueryModel;
        }
    }
}