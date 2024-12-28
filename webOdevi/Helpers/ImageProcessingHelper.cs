using OpenCvSharp;
using System;
using System.IO;

namespace webOdevi.Helpers
{
    public class ImageProcessingHelper
    {
        private readonly CascadeClassifier _faceCascade;

        public ImageProcessingHelper()
        {
            // Haar Cascade dosya yolunu belirle
            var cascadePath = Path.Combine(AppContext.BaseDirectory, "wwwroot/models/haarcascade_frontalface_default.xml");

            // Dosyanın varlığını kontrol et
            if (!File.Exists(cascadePath))
            {
                throw new FileNotFoundException($"Cascade file not found at {cascadePath}");
            }

            // CascadeClassifier oluştur
            _faceCascade = new CascadeClassifier(cascadePath);
        }

        // Yüzleri tespit eder ve üzerine öneriler ekler
        public Mat DetectFaces(string imagePath)
        {
            // Görüntüyü yükle
            Mat image = Cv2.ImRead(imagePath);
            if (image.Empty())
            {
                throw new Exception("Görüntü yüklenemedi!");
            }

            // Görüntüyü gri tonlamaya çevir
            Mat grayImage = new Mat();
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);

            // Yüzleri tespit et
            Rect[] faces = _faceCascade.DetectMultiScale(grayImage, 1.1, 6);
            if (faces.Length == 0)
            {
                throw new Exception("Yüz bulunamadı!");
            }

            // Yüzlere dikdörtgen çiz
            foreach (var face in faces)
            {
                Cv2.Rectangle(image, face, Scalar.Red, 2);
            }

            return image; // İşlenmiş görüntüyü döndür
        }

        // Görüntü üzerine saç şekli önerilerini döndürür
        public string GenerateSuggestions(Mat processedImage)
        {
            Console.WriteLine("1");
            // Yüzleri tespit edin
            Rect[] faces = _faceCascade.DetectMultiScale(processedImage, 1.1, 6);

            string suggestion = "Saç şekli ve rengi ile ilgili öneriler: \n";

            foreach (var face in faces)
            {
                // Yüz bölgesini kes
                Mat faceRegion = processedImage.SubMat(face);

                // Yüz şekline göre saç şekli önerisi
                string hairShapeSuggestion = GetHairShapeSuggestion(faceRegion);

                // Yüz bölgesine göre saç rengi önerisi
                string hairColorSuggestion = GetHairColorSuggestion(faceRegion);

                // Her yüz için öneriyi ekle
                suggestion += $"- {hairShapeSuggestion}\n- {hairColorSuggestion}\n";
            }

            return suggestion;
        }

        // Yüz şekline göre saç kesimi önerisi döndürür
        private string GetHairShapeSuggestion(Mat faceRegion)
        {
            Console.WriteLine("2");
            // Yüz şekline göre saç kesimi önerisi
            double aspectRatio = faceRegion.Width / (double)faceRegion.Height;

            if (aspectRatio < 0.95)
            {
                return "Yüz şeklinize göre önerdiğimiz saç kesimi: Uzun omuz hizası veya hafif katmanlı kesim.";
            }
            else if (aspectRatio >= 0.95 && aspectRatio <= 1.05)
            {
                return "Yüz şeklinize göre önerdiğimiz saç kesimi: Yanlardan hacimli veya orta uzunlukta bob kesim.";
            }
            else
            {
                return "Yüz şeklinize göre önerdiğimiz saç kesimi: Yandan ayrımlı düz saç.";
            }
        }

        // Saç rengine göre öneri döndürür
        private string GetHairColorSuggestion(Mat faceRegion)
        {
            Console.WriteLine("3");
            // Yüz bölgesine göre saç rengini önerir
            Scalar meanColor = Cv2.Mean(faceRegion); // Yüz bölgesinin ortalama rengi

            // Renk tonu değerlendirme
            if (meanColor[0] < 128) // Koyu renkli tonlar (Sıcak cilt tonları)
            {
                return "Sıcak cilt tonuna sahipsiniz.Saç rengi olarak önerilerimiz: Altın kahve, sıcak karameller.";
            }
            else // Açık renkli tonlar (Soğuk cilt tonları)
            {
                return "Soğuk cilt tonuna  sahipsiniz.Saç rengi olarak önerilerimiz: Platin sarısı, küllü tonlar.";
            }
        }
    }
}
