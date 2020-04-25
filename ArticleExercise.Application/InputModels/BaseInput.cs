using FluentValidation.Results;

namespace ArticleExercise.Application.InputModels
{
    public abstract class BaseInput
    {
        public abstract bool IsValid();
        protected ValidationResult ValidationResult { get; set; }
        public string ValidationMessage => ValidationResult.ToString();
    }
}