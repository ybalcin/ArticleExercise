using ArticleExercise.Application.Interfaces;
using ArticleExercise.Application.Services;
using ArticleExercise.Data.Context;
using ArticleExercise.Data.Repository;
using ArticleExercise.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleExercise.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IAppService), typeof(AppService));
            services.AddTransient<ApplicationDbContext>();
        }
    }
}