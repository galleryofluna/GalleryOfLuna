namespace GalleryOfLuna.Derpibooru.EntityFramework.Model
{
    public partial class GalleryInteraction
    {
        public long ImageId { get; set; }
        public long GalleryId { get; set; }
        public int Position { get; set; }
    }
}
