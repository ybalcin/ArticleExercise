using ArticleExercise.Application.InputModels;
using ArticleExercise.Domain.Core.Validator;
using FluentValidation;

namespace ArticleExercise.Application.Validations
{
    public class AddArticleToCategoryInputModelValidations : AbstractValidator<AddArticleToCategoryInputModel>
    {
        public AddArticleToCategoryInputModelValidations()
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

            RuleFor(r => r.AuthorId)
                .NotEmpty()
                .WithMessage("Yazar alanı boş geçilemez");

            RuleFor(r => r.AuthorId)
                .MustBeGuid(r => r.AuthorId)
                .When(f => !string.IsNullOrEmpty(f.AuthorId));
        }
    }
}