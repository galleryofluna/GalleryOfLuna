namespace GalleryOfLuna.ImageProvider.Derpibooru
{
    public class DerpibooruImageProviderSettings
    {
        public string ApiKey { get; }
        
        // TODO: Specify this search option by enum
        public string OrderBy { get; }
    }
}