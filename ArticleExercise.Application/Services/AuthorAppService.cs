using System;
using ArticleExercise.Application.Interfaces;

namespace ArticleExercise.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}