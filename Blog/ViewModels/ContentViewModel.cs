using Blog.Models;

namespace Blog.ViewModels
{
    public class ContentViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Publication> Publications { get; set; }

    }
}
