using System.Collections;
using System.Collections.Generic;
using ArticleExercise.Domain.Core.Models;

namespace ArticleExercise.Domain.Models
{
    public class Author : Entity
    {
        public Author()
        {
            Articles = new HashSet<Article>();
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}