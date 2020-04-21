using System;
using ArticleExercise.Application.Interfaces;

namespace ArticleExercise.Application.Services
{
    public class ArticleAppService : IArticleAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}