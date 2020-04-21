using ArticleExercise.Application.Interfaces;
using ArticleExercise.Data.Context;
using ArticleExercise.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleExercise.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            
            services.Scan(p =>
                p.FromAssembliesOf(typeof(IAppService))
                    .AddClasses(classes => classes.AssignableTo(typeof(IAppService)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );
            
            services.Scan(p =>
                p.FromApplicationDependencies()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );
            
            services.AddTransient<ApplicationDbContext>();
        }
    }
}