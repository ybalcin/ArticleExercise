using System;
using System.Collections.Generic;
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

        public void Add(ArticleViewModel model)
        {
            _articleRepository.Add(_mapper.Map<Article>(model));
        }
    }
}