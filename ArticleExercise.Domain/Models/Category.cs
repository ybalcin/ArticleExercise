using System.Collections.Generic;
using ArticleExercise.Domain.Core.Models;

namespace ArticleExercise.Domain.Models
{
    public class Category: Entity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}