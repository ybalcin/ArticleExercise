using ArticleExercise.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleExercise.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<ApplicationDbContext>();
        }
    }
}