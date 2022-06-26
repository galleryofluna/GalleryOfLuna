namespace GalleryOfLuna.Derpibooru.EntityFramework.Model
{
    public partial class ImageSource
    {
        public long ImageId { get; set; }
        public string Source { get; set; } = null!;

        public virtual Image Image { get; set; } = null!;
    }
}
