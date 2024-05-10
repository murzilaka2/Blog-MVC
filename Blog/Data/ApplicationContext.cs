using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publication> Publications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publication>()
                    .HasMany<Category>(s => s.Categories)
                    .WithMany(c => c.Publications)
                    .UsingEntity(e => e.ToTable("PublicationCategoryRelations"));


            modelBuilder.Entity<Publication>().Property(e => e.TotalViews).HasDefaultValue(1);
            modelBuilder.Entity<Publication>().Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");


            base.OnModelCreating(modelBuilder);
        }

    }
}
