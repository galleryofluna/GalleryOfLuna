using GalleryOfLuna.Model.Entities;

namespace GalleryOfLuna.Abstractions
{
    public interface IImageProvider
    {
        IEnumerable<Image> Search(string userQuery);
    }
}