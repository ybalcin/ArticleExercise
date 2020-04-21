using System.Collections.Generic;

namespace ArticleExercise.Application.ViewModels
{
    public class AuthorViewModel : BaseViewModel
    {
        public AuthorViewModel()
        {
            Articles = new HashSet<ArticleViewModel>();
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public ICollection<ArticleViewModel> Articles { get; set; }
    }
}