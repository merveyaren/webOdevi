using System.ComponentModel.DataAnnotations;

namespace webOdevi.Models
{
    public class PhotoUploadModel
    {
        [Required]
        public IFormFile? Photo { get; set; }

        [Required]
        public string output_url { get; set; }

        // Parametreli oluşturucu
        public PhotoUploadModel(IFormFile photo, string outputUrl)
        {
            Photo = photo;
            output_url = outputUrl;
        }

        // Varsayılan oluşturucu
        public PhotoUploadModel()
        {
        }
    }



}
