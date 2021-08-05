using System;
using System.Collections.Generic;

namespace GalleryOfLuna.Model.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id">Internal identifier of image from image provider</param>
    /// <param name="ProviderName">Name of image provider</param>
    /// <param name="Representations">URIs of image representations</param>
    public record ImageSource(string Id, string ProviderName, IReadOnlyDictionary<string, Uri> Representations);
}