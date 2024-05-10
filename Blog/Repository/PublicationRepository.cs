using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class PublicationRepository : IPublication
    {
        private readonly ApplicationContext _context;


        public PublicationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddPublicationAsync(Publication publication)
        {
            if (publication.Categories.Count > 0)
            {
                var categoriesId = publication.Categories.Select(e => e.Id).ToArray();
                var allCategories = _context.Categories.Where(e => categoriesId.Contains(e.Id)).ToList();


                publication.Categories = allCategories;
            }


            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePublicationAsync(Publication publication)
        {
            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationsWithCategoriesAsync()
        {
            return await _context.Publications.Include(e => e.Categories).ToListAsync();
        }

        public async Task<Publication> GetPublicationAsync(string id)
        {
            return await _context.Publications.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }


        public async Task<Publication> GetPublicationWithCategoriesAsync(string id)
        {
            return await _context.Publications.Include(e => e.Categories).FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }


        public async Task UpdatePublicationAsync(Publication publication)
        {
            var categoriesId = publication.Categories.Select(e => e.Id).ToArray();
            var allCategories = _context.Categories.Where(e => categoriesId.Contains(e.Id)).ToList();


            var currentPublication = await GetPublicationWithCategoriesAsync(publication.Id.ToString());
            currentPublication.Title = publication.Title;
            currentPublication.Description = publication.Description;
            currentPublication.Categories = allCategories;
            currentPublication.SeoDescription = publication.SeoDescription;
            currentPublication.Keywords = publication.Keywords;
            currentPublication.FullImageName = publication.FullImageName;
            currentPublication.Image = publication.Image;


            _context.Publications.Update(currentPublication);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateViewsAsync(string id)
        {
            await _context.Database.ExecuteSqlRawAsync($"UPDATE [Publications] SET [TotalViews] += 1 WHERE Id = '{id}'");
        }
    }

}
