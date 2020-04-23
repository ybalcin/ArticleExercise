using System;
using System.Collections.Generic;
using System.Linq;
using ArticleExercise.Application.InputModels;
using ArticleExercise.Application.Interfaces;
using ArticleExercise.Application.ViewModels;
using ArticleExercise.Domain.Interfaces;
using ArticleExercise.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ArticleExercise.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AuthorAppService(IMapper mapper, IAuthorRepository authorRepository,
            IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AuthorViewModel Add(AuthorInputModel input)
        {
            var viewModel = _mapper.Map<AuthorViewModel>(input);
            var author = _authorRepository.Add(_mapper.Map<Author>(viewModel));
            return _mapper.Map<AuthorViewModel>(author);
        }

        public IEnumerable<AuthorViewModel> GetAll()
        {
            return _authorRepository.GetAll().ProjectTo<AuthorViewModel>(_mapper.ConfigurationProvider);
        }

        public AuthorViewModel GetAuthor(string id)
        {
            return _mapper.Map<AuthorViewModel>(_authorRepository.Find(id));
        }

        public ArticleViewModel AddArticle(AddArticleToAuthorInputModel input, string authorId)
        {
            var article = _mapper.Map<Article>(input);
            _authorRepository.AddArticle(authorId, article);
            article.Category = _categoryRepository.Find(input.CategoryId);
            return _mapper.Map<ArticleViewModel>(article);
        }

        public IEnumerable<ArticleViewModel> GetArticles(string id)
        {
            return _articleRepository.GetAll(f => f.AuthorId == id)
                .ProjectTo<ArticleViewModel>(_mapper.ConfigurationProvider);
        }
    }
}