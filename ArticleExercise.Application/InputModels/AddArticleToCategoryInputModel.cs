using ArticleExercise.Application.Validations;

namespace ArticleExercise.Application.InputModels
{
    public class AddArticleToCategoryInputModel : BaseInput
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Detail { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string AuthorId { get; set; }
        
        public override bool IsValid()
        {
            ValidationResult = new AddArticleToCategoryInputModelValidations().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}