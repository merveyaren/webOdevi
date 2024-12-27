using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OpenCvSharp;
using System.IO;
using System;
using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class FotoController : Controller
    {
        [HttpGet]
        [Route("Foto")]
        public IActionResult Foto()
        {
            var model = new PhotoUploadModel
            {
                output_url = null
            };
            return View("~/Views/Home/Foto.cshtml", model);
        }

        [HttpPost]
        [Route("Foto/ModifyPhoto")]
        public IActionResult Foto(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                try
                {
                    var safeFileName = Path.GetFileNameWithoutExtension(photo.FileName) + Path.GetExtension(photo.FileName);
                    var tempPath = Path.Combine(Path.GetTempPath(), safeFileName);
                    var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "modified_" + safeFileName);

                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }

                    var fileBytes = System.IO.File.ReadAllBytes(tempPath);
                    using (var img = OpenCvSharp.Mat.FromImageData(fileBytes))
                    {
                        if (img.Empty())
                        {
                            throw new Exception("Görsel yüklenemedi.");
                        }

                        var grayImg = new OpenCvSharp.Mat();
                        Cv2.CvtColor(img, grayImg, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
                        Cv2.ImWrite(outputPath, grayImg);
                    }

                    var model = new PhotoUploadModel(photo, "/images/modified_" + safeFileName);
                    return View("~/Views/Home/Foto.cshtml", model);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                    return View("~/Views/Home/Foto.cshtml", new PhotoUploadModel());
                }
            }
            else
            {
                return View("~/Views/Home/Foto.cshtml", new PhotoUploadModel());
            }
        }
    }
}
