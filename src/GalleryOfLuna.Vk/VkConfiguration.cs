using System.ComponentModel.DataAnnotations;

namespace GalleryOfLuna.Vk
{
    public class VkConfiguration
    {
        [Required]
        public string AccessToken { get; set; } = string.Empty;

        [Required]
        public long GroupId { get; set; }
    }
}