using System.ComponentModel.DataAnnotations;

namespace url_shortner.Models
{
    public class ShortUrls
    {
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }
    }
}
