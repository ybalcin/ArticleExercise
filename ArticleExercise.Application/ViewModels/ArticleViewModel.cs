namespace ArticleExercise.Application.ViewModels
{
    public class ArticleViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Detail { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public int Like { get; set; } = 0;
        
        // public string AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }
        // public string CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}