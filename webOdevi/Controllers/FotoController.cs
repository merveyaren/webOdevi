using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OpenCvSharp;
using System.Threading.Tasks;
using System.IO;
using System;
using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class FotoController : Controller
    {
        [HttpPost]
        [Route("Foto/ModifyPhoto")]
        public IActionResult Foto(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                // Geçici dosya yolu
                var tempPath = Path.Combine(Path.GetTempPath(), photo.FileName);
                using (var stream = new FileStream(tempPath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }

                // OpenCV ile okuma ve işlem yapma
                var outputPath = Path.Combine(Path.GetTempPath(), "modified_" + photo.FileName);
                try
                {
                    using (var img = OpenCvSharp.Mat.FromImageData(System.IO.File.ReadAllBytes(tempPath)))
                    {
                        var grayImg = new OpenCvSharp.Mat();
                        Cv2.CvtColor(img, grayImg, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
                        Cv2.ImWrite(outputPath, grayImg);
                    }

                    // Model oluştur ve View'e gönder
                    var model = new PhotoUploadModel
                    {
                        output_url = "/images/modified_" + photo.FileName // Görünümde görüntülenecek dosya yolu
                    };
                    return View("Foto", model);
                }
                catch (Exception ex)
                {
                    // Hata durumunda boş model gönder
                    Console.WriteLine("Hata: " + ex.Message);
                    return View("Foto", new PhotoUploadModel());
                }
            }
            else
            {
                // Fotoğraf yoksa boş bir model gönder
                return View("Foto", new PhotoUploadModel());
            }
        }

    }
}

