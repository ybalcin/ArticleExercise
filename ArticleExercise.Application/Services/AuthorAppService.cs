using System;
using ArticleExercise.Application.Interfaces;

namespace ArticleExercise.Application.Services
{
    public class AuthorAppService : AppService, IAuthorAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}