using ArticleExercise.Application.ViewModels;
using ArticleExercise.Domain.Models;
using AutoMapper;

namespace ArticleExercise.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ArticleViewModel, Article>();
            CreateMap<AuthorViewModel, Author>();
        }
    }
}