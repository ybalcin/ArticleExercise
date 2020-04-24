
using ArticleExercise.Application.Validations;

namespace ArticleExercise.Application.InputModels
{
    public class AddCategoryInputModel : BaseInput
    {
        public string Name { get; set; }
        
        public override bool IsValid()
        {
            ValidationResult = new CategoryInputModelValidations().Validate(this);
            return ValidationResult.IsValid;
        }

        public override string GetErrorMessage()
        {
            return ValidationResult.ToString();
        }
    }
}