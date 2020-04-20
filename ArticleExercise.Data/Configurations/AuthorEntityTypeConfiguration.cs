using ArticleExercise.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleExercise.Data.Configurations
{
    public class AuthorEntityTypeConfiguration : EntityTypeConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Authors", "dbo");
            
            builder.HasQueryFilter(p => p.IsActive)
                .HasQueryFilter(p => !p.IsDeleted);
        }
    }
}