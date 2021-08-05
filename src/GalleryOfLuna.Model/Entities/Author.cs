using GalleryOfLuna.Model.Identifiers;

namespace GalleryOfLuna.Model
{
    public class Author
    {
        public AuthorId Id { get; }
        
        public string Nickname { get; }
        
        public string Bio { get; }
        
        public string Site { get; }
    }
}