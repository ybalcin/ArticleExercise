using ArticleExercise.Application.Validations;

namespace ArticleExercise.Application.InputModels
{
    public class AuthorInputModel : BaseInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        
        public override bool IsValid()
        {
            ValidationResult = new AuthorInputModelValidations().Validate(this);
            return ValidationResult.IsValid;
        }

        public override string GetErrorMessage()
        {
            return ValidationResult.ToString();
        }
    }
}