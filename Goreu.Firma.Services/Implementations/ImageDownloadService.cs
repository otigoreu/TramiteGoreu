using Goreu.Firma.Services.Interfaces;

namespace Goreu.Firma.Services.Implementations
{
    public class ImageDownloadService : IImageDownloadService
    {
        private readonly IHostingEnvironment _env;

        public ImageDownloadService(IHostingEnvironment env)
        {
            _env = env;
        }

        // Método para obtener la ruta completa de la imagen
        public string GetImagePath()
        {
            return Path.Combine(_env.WebRootPath, "Images", $"stamp.png");
        }

        // Método para verificar si la imagen existe
        public bool ImageExists(string imagePath)
        {
            return File.Exists(imagePath);
        }

        // Método para obtener los bytes de la imagen
        public async Task<byte[]> GetImageBytesAsync(string imagePath)
        {
            return await File.ReadAllBytesAsync(imagePath);
        }
    }
}
