using ArticleExercise.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleExercise.Data.Configurations
{
    public class CategoryEntityTypeConfiguration : EntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Categories", "dbo");
            
            builder.HasQueryFilter(p => p.IsActive)
                .HasQueryFilter(p => !p.IsDeleted);
        }
    }
}