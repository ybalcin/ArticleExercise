using System;
using System.Collections.Generic;
using System.Net;
using ArticleExercise.Application.InputModels;
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
        private readonly IAuthorAppService _authorAppService;
        private readonly ISearchService _searchService;

        public BlogController(ICategoryAppService categoryAppService, IArticleAppService articleAppService,
            IAuthorAppService authorAppService, ISearchService searchService)
        {
            _categoryAppService = categoryAppService;
            _articleAppService = articleAppService;
            _authorAppService = authorAppService;
            _searchService = searchService;
        }

        #region Categories

        [HttpGet("categories")]
        public IActionResult Category()
        {
            return new OkObjectResult(_categoryAppService.GetCategories());
        }

        [HttpGet("categories/{id}")]
        public IActionResult Category(string id)
        {
            return new OkObjectResult(_categoryAppService.GetCategory(id));
        }
        
        [HttpPut("categories/{id}")]
        public IActionResult UpdateCategory([FromBody] AddCategoryInputModel input ,string id)
        {
            if (!input.IsValid()) return BadRequest(input.ValidationMessage);
            return new OkObjectResult(_categoryAppService.Update(input.Name, id));
        }

        [HttpPost("categories")]
        public IActionResult AddCategory(AddCategoryInputModel input)
        {
            if (!input.IsValid()) return BadRequest(input.ValidationMessage);
            var category = _categoryAppService.AddCategory(input);
            return Created(new Uri($"{Request.Path}/{category.Id}", UriKind.Relative), category);
        }
        
        [HttpPut("categories/{id}/articles")]
        public IActionResult AddArticleToCategory([FromBody] AddArticleToCategoryInputModel input, string id)
        {
            if (!input.IsValid()) return BadRequest(input.ValidationMessage);
            var article = _categoryAppService.AddArticle(input, id);
            return Created($"/articles/{article.Id}", article);
        }

        [HttpGet("categories/{id}/articles")]
        public IActionResult GetCategoryArticles(string id)
        {
            var category = _categoryAppService.GetCategory(id);
            if (category == null) return BadRequest("Category not found");
            return new OkObjectResult(_categoryAppService.GetArticles(id));
        }

        #endregion

        #region Articles

        [HttpGet("articles")]
        public IActionResult GetArticles()
        {
            return new OkObjectResult(_articleAppService.GetAll());
        }
        
        [HttpGet("articles/{id}")]
        public IActionResult GetArticle(string id)
        {
            return new OkObjectResult(_articleAppService.GetDetail(id));
        }
        
        [HttpDelete("articles/{id}")]
        public IActionResult RemoveArticle(string id)
        {
            if (_articleAppService.GetArticle(id) == null) return BadRequest("Article not found");
            _articleAppService.Remove(id);
            return Ok();
        }

        [HttpPatch("articles/{id}/like")]
        public IActionResult Like(string id)
        {
            var article = _articleAppService.GetArticle(id);
            if (article == null) return BadRequest("Article not found");
            _articleAppService.Like(id);
            return Ok();
        }

        #endregion

        #region Authors

        [HttpPost("authors")]
        public IActionResult AddAuthor(AuthorInputModel input)
        {
            if (!input.IsValid()) return BadRequest(input.ValidationMessage);
            var author = _authorAppService.Add(input);
            return Created(new Uri($"{Request.Path}/{author.Id}", UriKind.Relative), author);
        }

        [HttpGet("authors")]
        public IActionResult GetAuthors()
        {
            return new OkObjectResult(_authorAppService.GetAll());
        }

        [HttpGet("authors/{id}")]
        public IActionResult GetAuthor(string id)
        {
            return new OkObjectResult(_authorAppService.GetAuthor(id));
        }

        [HttpPut("authors/{id}/articles")]
        public IActionResult AddArticle([FromBody] AddArticleToAuthorInputModel input, string id)
        {
            if (!input.IsValid()) return BadRequest(input.ValidationMessage);
            var author = _authorAppService.GetAuthor(id);
            if (author == null) return BadRequest("Author not found");

            var article = _authorAppService.AddArticle(input, id);
            return Created(new Uri($"/articles/{article.Id}", UriKind.Relative), article);
        }

        [HttpGet("authors/{id}/articles")]
        public IActionResult GetAuthorArticles(string id)
        {
            var author = _authorAppService.GetAuthor(id);
            if (author == null) return BadRequest("Author not found");
            
            return new OkObjectResult(_authorAppService.GetArticles(id));
        }

        #endregion

        [HttpGet("search/{searchText}")]
        public IActionResult Search(string searchText)
        {
            return Ok(_searchService.Search(searchText));
        }
    }
}