using Microsoft.EntityFrameworkCore;

namespace GalleryOfLuna.EntityFramework.Sqlite
{
    public sealed class SqlitePublishingDbContext : PublishingDbContext
    {
        public SqlitePublishingDbContext(DbContextOptions<SqlitePublishingDbContext> options) : base(options)
        {
        }
    }
}