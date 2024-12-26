using System.ComponentModel.DataAnnotations;

namespace webOdevi.Models
{
    public class PhotoUploadModel
    {
        [Required]
        public IFormFile Photo { get; set; }
        public string output_url { get; set; }
    }

}
