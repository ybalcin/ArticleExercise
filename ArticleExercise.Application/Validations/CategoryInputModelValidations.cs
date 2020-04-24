using ArticleExercise.Application.InputModels;
using FluentValidation;

namespace ArticleExercise.Application.Validations
{
    public class CategoryInputModelValidations : AbstractValidator<AddCategoryInputModel>
    {
        public CategoryInputModelValidations()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Kategori adı alanı boş geçilemez");
        }
    }
}