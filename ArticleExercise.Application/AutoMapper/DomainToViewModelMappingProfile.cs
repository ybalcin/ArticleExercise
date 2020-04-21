using ArticleExercise.Application.ViewModels;
using ArticleExercise.Domain.Models;
using AutoMapper;

namespace ArticleExercise.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Author, AuthorViewModel>();
        }
    }
}