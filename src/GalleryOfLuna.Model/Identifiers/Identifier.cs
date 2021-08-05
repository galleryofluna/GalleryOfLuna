namespace GalleryOfLuna.Model.Identifiers
{
    public abstract record Identifier<T> 
        where T : struct  
    {
        // TODO: Specify type in XML doc 
        /// <summary>
        /// Identifier of entity
        /// </summary>
        public T Value { get; }
    }
}