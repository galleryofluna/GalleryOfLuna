namespace GalleryOfLuna.Configuration
{
    public enum DatabaseTypes
    {
        Default,

        SQLite,
        PostgreSQL,

#if DEBUG
        InMemory
#endif
    }
}