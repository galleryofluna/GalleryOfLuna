using GalleryOfLuna.Model.Identifiers;
using GalleryOfLuna.Model.ValueObjects;

namespace GalleryOfLuna.Model.Entities
{
    public class Image
    {
        /// <inheritdoc cref="Identifier{T}.Value"/>
        public ImageId Id { get; }
        
        /// <summary>
        /// Description of image author. 
        /// </summary>
        public Author Author { get; }

        public List<Tag> Tags { get; }

        public List<ImageSource> Sources { get; }

        public bool IsExplicit => Tags.Any(tag => tag.IsExplicit);
    }
}