using System;
using ArticleExercise.Application.Interfaces;

namespace ArticleExercise.Application.Services
{
    public class CategoryAppService : AppService, ICategoryAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}