using System.Collections.Generic;

namespace ArticleExercise.Domain.QueryModels
{
    public class SearchQueryModel
    {
        public SearchQueryModel()
        {
            Contents = new HashSet<SearchContent>();
        }
        public string SearchText { get; set; }
        public ICollection<SearchContent> Contents { get; set; }
    }

    public class SearchContent
    {
        public string Module { get; set; }
        public object Data { get; set; }
    }
}