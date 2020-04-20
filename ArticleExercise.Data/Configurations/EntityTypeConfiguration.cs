using ArticleExercise.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleExercise.Data.Configurations
{
    public abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}