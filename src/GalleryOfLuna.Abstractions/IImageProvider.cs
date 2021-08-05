using System.Collections.Generic;
using GalleryOfLuna.Model;

namespace GalleryOfLuna.Abstractions
{
    public interface IImageProvider
    {
        IEnumerable<Image> Search(string userQuery);
    }
}