using System.Collections.Generic;
using ArticleExercise.Application.Interfaces;
using ArticleExercise.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArticleExercise.API.Controllers.Api
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IArticleAppService _articleAppService;

        public BlogController(ICategoryAppService categoryAppService, IArticleAppService articleAppService)
        {
            _categoryAppService = categoryAppService;
            _articleAppService = articleAppService;
        }

        [HttpGet("categories")]
        public IEnumerable<CategoryViewModel> Category()
        {
            return _categoryAppService.GetCategories();
        }

        [HttpPost("categories")]
        public IActionResult AddCategory(string name)
        {
            _categoryAppService.AddCategory(name);
            return Ok();
        }

        [HttpGet("articles")]
        public IEnumerable<ArticleViewModel> GetArticles()
        {
            return _articleAppService.GetAll();
        }

        [HttpPost("articles")]
        public IActionResult Articles(ArticleViewModel model)
        {
            _articleAppService.Add(model);
            return Ok();
        }
    }
}