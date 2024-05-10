namespace Blog.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }


        public virtual ICollection<Publication> Publications { get; set; }
    }

}
