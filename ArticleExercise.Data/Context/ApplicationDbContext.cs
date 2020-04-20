using ArticleExercise.Data.Configurations;
using ArticleExercise.Domain.Core.Models;
using ArticleExercise.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ArticleExercise.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IWebHostEnvironment _env;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env)
            : base(options)
        {
            _env = env;
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Entity>().HasKey(p => p.Id);
            // modelBuilder.Entity<Entity>()
            //     .HasQueryFilter(p => p.IsActive)
            //     .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}