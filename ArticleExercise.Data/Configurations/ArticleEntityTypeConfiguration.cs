using ArticleExercise.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleExercise.Data.Configurations
{
    public class ArticleEntityTypeConfiguration : EntityTypeConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Articles", "dbo");
            
            builder.HasOne(o => o.Author)
                .WithMany(m => m.Articles)
                .HasForeignKey(k => k.AuthorId);

            builder.HasOne(o => o.Category)
                .WithMany(m => m.Articles)
                .HasForeignKey(k => k.CategoryId);

            builder.HasQueryFilter(p => p.IsActive)
                .HasQueryFilter(p => !p.IsDeleted);
        }
    }
}