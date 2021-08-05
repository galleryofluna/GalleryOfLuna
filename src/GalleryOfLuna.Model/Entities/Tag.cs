using GalleryOfLuna.Model.Identifiers;

namespace GalleryOfLuna.Model
{
    public class Tag
    {
        public TagId Id { get; }
        
        public string Name { get; }
        
        public bool IsExplicit { get; }
    }
}