using Microsoft.EntityFrameworkCore;

namespace GalleryOfLuna.EntityFramework.PostgreSQL
{
    public sealed class PostgreSqlPublishingDbContext : PublishingDbContext
    {
        public PostgreSqlPublishingDbContext(DbContextOptions<PostgreSqlPublishingDbContext> options) : base(options)
        {
        }
    }
}