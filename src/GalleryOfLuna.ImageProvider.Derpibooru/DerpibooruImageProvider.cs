using System;
using System.Collections.Generic;
using System.Net.Http;
using GalleryOfLuna.Abstractions;
using GalleryOfLuna.Model;

namespace GalleryOfLuna.ImageProvider.Derpibooru
{
    // TODO: Derpibooru provider nightly dumps of database.
    // That might be useful to avoid too many requests on them and search independently
    public sealed class DerpibooruImageProvider : IImageProvider, IDisposable
    {
        private readonly HttpClient _httpClient;
        
        public DerpibooruImageProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public IEnumerable<Image> Search(string userQuery)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}