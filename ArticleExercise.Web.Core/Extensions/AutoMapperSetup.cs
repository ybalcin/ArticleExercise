using System;
using ArticleExercise.Application.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleExercise.Web.Core.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}