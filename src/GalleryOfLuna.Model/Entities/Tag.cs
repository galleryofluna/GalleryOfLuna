using GalleryOfLuna.Model.Identifiers;

namespace GalleryOfLuna.Model.Entities
{
    public class Tag
    {
        public TagId Id { get; }
        
        public string Name { get; }
        
        public bool IsExplicit { get; }
    }
}