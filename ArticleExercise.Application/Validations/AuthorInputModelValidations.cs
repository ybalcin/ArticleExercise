using ArticleExercise.Application.InputModels;
using FluentValidation;

namespace ArticleExercise.Application.Validations
{
    public class AuthorInputModelValidations: AbstractValidator<AuthorInputModel>
    {
        public AuthorInputModelValidations()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty()
                .WithMessage("Yazar adı alanı boş geçilemez");

            RuleFor(r => r.LastName)
                .NotEmpty()
                .WithMessage("Yazar soyadı alanı boş geçilemez");
        }
    }
}