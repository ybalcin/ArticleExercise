using ArticleExercise.Application.Validations;

namespace ArticleExercise.Application.InputModels
{
    public class AddArticleToAuthorInputModel : BaseInput
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Detail { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string CategoryId { get; set; }
        
        public override bool IsValid()
        {
            ValidationResult = new AddArticleToAuthorInputModelValidations().Validate(this);
            return ValidationResult.IsValid;
        }

        public override string GetErrorMessage()
        {
            return ValidationResult.ToString();
        }
    }
}