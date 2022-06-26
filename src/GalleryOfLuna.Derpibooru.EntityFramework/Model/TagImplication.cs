namespace GalleryOfLuna.Derpibooru.EntityFramework.Model
{
    public partial class TagImplication
    {
        public long TagId { get; set; }
        public long TargetTagId { get; set; }

        public virtual Tag Tag { get; set; } = null!;
        public virtual Tag TargetTag { get; set; } = null!;
    }
}
