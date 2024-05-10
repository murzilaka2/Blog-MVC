using Blog.Models;

namespace Blog.Interfaces
{
    public interface IPublication
    {
        Task<IEnumerable<Publication>> GetAllPublicationsAsync();
        Task<IEnumerable<Publication>> GetAllPublicationsWithCategoriesAsync();
        Task<Publication> GetPublicationAsync(string id);
        Task<Publication> GetPublicationWithCategoriesAsync(string id);


        Task UpdateViewsAsync(string id);


        Task AddPublicationAsync(Publication publication);
        Task UpdatePublicationAsync(Publication publication);
        Task DeletePublicationAsync(Publication publication);
    }
}
