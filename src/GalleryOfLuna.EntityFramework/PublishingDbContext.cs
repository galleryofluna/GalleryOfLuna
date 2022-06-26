using GalleryOfLuna.EntityFramework.Model;

using Microsoft.EntityFrameworkCore;

namespace GalleryOfLuna.EntityFramework
{
    public class PublishingDbContext : DbContext
    {
        public DbSet<PublishedImage> PublishedImages { get; set; } = null!;

        public PublishingDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
