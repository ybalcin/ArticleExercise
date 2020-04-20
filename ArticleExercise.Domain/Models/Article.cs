using System.Collections.Generic;
using ArticleExercise.Domain.Core.Models;

namespace ArticleExercise.Domain.Models
{
    public class Article : Entity
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Detail { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public int Like { get; set; } = 0;

        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}