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
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void AddCategory(string name)
        {
            _categoryRepository.Add(_mapper.Map<Category>(new CategoryViewModel(){Name = name}));
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _categoryRepository.GetAll().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
        }
    }
}