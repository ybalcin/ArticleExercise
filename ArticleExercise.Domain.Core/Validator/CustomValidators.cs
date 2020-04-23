using System;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace ArticleExercise.Domain.Core.Validator
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> MustBeGuid<T>
            (this IRuleBuilder<T, string> ruleBuilder, Expression<Func<T, string>> property)
        {
            return ruleBuilder.Must(f => Guid.TryParse(f, out var result))
                .WithMessage($"Geçerli bir {property.GetMember().Name} giriniz");
        }
    }
}