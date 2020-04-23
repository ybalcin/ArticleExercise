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
    public class ArticleAppService : IArticleAppService
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public ArticleAppService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ArticleViewModel> GetAll()
        {
            return _articleRepository.GetAll().ProjectTo<ArticleViewModel>(_mapper.ConfigurationProvider);
        }

        public void Add(AddArticleToAuthorInputModel model)
        {
            var viewModel = _mapper.Map<ArticleViewModel>(model);
            _articleRepository.Add(_mapper.Map<Article>(viewModel));
        }

        public ArticleViewModel GetArticle(string id)
        {
            return _mapper.Map<ArticleViewModel>(_articleRepository.Find(id));
        }

        public void Like(string id)
        {
            _articleRepository.Like(id);
        }

        public ArticleViewModel GetDetail(string id)
        {
            return _mapper.Map<ArticleViewModel>(_articleRepository.GetDetail(id));
        }
    }
}