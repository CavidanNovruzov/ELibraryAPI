
using Microsoft.AspNetCore.Hosting;
using ELibraryAPI.Application.Abstractions.Services.Storage;

namespace ELibraryAPI.Infrastructure.Services.Storage
{
    public class LocalStorage : IStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadAsync(string base64Data, string fileName, string path)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string fileExtension = Path.GetExtension(fileName);
            string newFileName = $"{Guid.NewGuid()}{fileExtension}";
            string fullPath = Path.Combine(uploadPath, newFileName);

            var base64Part = base64Data.Contains(",") ? base64Data.Split(',')[1] : base64Data;
            byte[] fileBytes = Convert.FromBase64String(base64Part);

            await File.WriteAllBytesAsync(fullPath, fileBytes);

            return $"/uploads/{path}/{newFileName}";
        }

        public void Delete(string path, string fileName)
        {
            string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", path, fileName);
            if (File.Exists(fullPath)) File.Delete(fullPath);
        }

        public bool HasFile(string path, string fileName)
            => File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, "uploads", path, fileName));
    }
}
