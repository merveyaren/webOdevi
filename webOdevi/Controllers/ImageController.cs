using Microsoft.AspNetCore.Mvc;
using webOdevi.Helpers;
using System.IO;
using OpenCvSharp;

namespace webOdevi.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageProcessingHelper _imageProcessor;

        public ImageController()
        {
            _imageProcessor = new ImageProcessingHelper();
        }

        [HttpPost]
        public IActionResult Foto(IFormFile uploadedImage)
        {
            if (uploadedImage == null || uploadedImage.Length == 0)
            {
                ViewBag.ErrorMessage = "Lütfen bir görüntü yükleyin.";
                return View();
            }

            var tempDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/temp");
            Directory.CreateDirectory(tempDir); //temp klasör oluşuyo

            var filePath = Path.Combine(tempDir, uploadedImage.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                uploadedImage.CopyTo(stream);
            }

            try
            {
                var processedImage = _imageProcessor.DetectFaces(filePath);
                var suggestions = _imageProcessor.GenerateSuggestions(processedImage); // Öneriler oluşuyor

                // İşlenmiş görüntü üzerine öneriler
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/processed_image_with_suggestions.jpg");
                Cv2.ImWrite(outputPath, processedImage);

                // İşlenmiş görüntüyü ve önerileri View'e gönder
                ViewBag.ProcessedImagePath = "/images/processed_image_with_suggestions.jpg";
             
                ViewBag.HairSuggestions = suggestions.Split('\n').ToList(); 
                return View("~/Views/Home/Foto.cshtml");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Görüntü işleme sırasında hata oluştu: {ex.Message}";
                return View("Home/Foto");
            }
        }
    }
}
