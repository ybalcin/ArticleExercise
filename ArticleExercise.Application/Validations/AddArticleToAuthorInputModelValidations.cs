using ArticleExercise.Application.InputModels;
using FluentValidation;
using ArticleExercise.Domain.Core.Validator;

namespace ArticleExercise.Application.Validations
{
    public class AddArticleToAuthorInputModelValidations : AbstractValidator<AddArticleToAuthorInputModel>
    {
        public AddArticleToAuthorInputModelValidations()
        {
            RuleFor(r => r.Detail)
                .NotEmpty()
                .WithMessage("Detay alanı boş geçilemez");

            RuleFor(r => r.Title)
                .NotEmpty()
                .WithMessage("Başlık alanı boş geçilemez");

            RuleFor(r => r.Topic)
                .NotEmpty()
                .WithMessage("Konu alanı boş geçilemez");

            RuleFor(r => r.CategoryId)
                .NotEmpty()
                .WithMessage("Kategori alanı boş geçilemez");

            RuleFor(r => r.CategoryId)
                .MustBeGuid(r => r.CategoryId)
                .When(r => !string.IsNullOrEmpty(r.CategoryId));
        }
    }
}