using System;
using System.Collections.Generic;
using ArticleExercise.Application.InputModels;
using ArticleExercise.Application.Interfaces;
using ArticleExercise.Application.ViewModels;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ArticleExercise.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IAuthorRepository _authorRepository;

        public CategoryAppService(ICategoryRepository categoryRepository, IMapper mapper,
            IArticleRepository articleRepository, IAuthorRepository authorRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public CategoryViewModel AddCategory(CategoryInputModel input)
        {
            var viewModel = _mapper.Map<CategoryViewModel>(input);
            var category = _categoryRepository.Add(_mapper.Map<Category>(viewModel));
            return _mapper.Map<CategoryViewModel>(category);
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _categoryRepository.GetAll().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
        }

        public CategoryViewModel GetCategory(string id)
        {
            return _mapper.Map<CategoryViewModel>(_categoryRepository.Find(id));
        }

        public ArticleViewModel AddArticle(AddArticleToCategoryInputModel input, string categoryId)
        {
            var article = _mapper.Map<Article>(input);
            _categoryRepository.AddArticle(article, categoryId);
            article.Author = _authorRepository.Find(input.AuthorId);
            return _mapper.Map<ArticleViewModel>(article);
        }

        public IEnumerable<ArticleViewModel> GetArticles(string categoryId)
        {
            return _articleRepository.GetAll(f => f.CategoryId == categoryId)
                .ProjectTo<ArticleViewModel>(_mapper.ConfigurationProvider);
        }
    }
}