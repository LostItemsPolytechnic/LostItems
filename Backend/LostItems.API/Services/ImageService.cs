using LostItems.API.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace LostItems.API.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadImage(byte[] imageData, string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string uniqueFileName = Guid.NewGuid().ToString() + extension;
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string filePath = Path.Combine(uploadFolder, uniqueFileName);
            File.WriteAllBytes(filePath, imageData);

            return $"/images/{uniqueFileName}";
        }

        public byte[] GetImage(string imageUrl)
        {
            string fileName = Path.GetFileName(imageUrl);
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"Image not found at path: {imagePath}");
            }

            return File.ReadAllBytes(imagePath);
        }
    }
}