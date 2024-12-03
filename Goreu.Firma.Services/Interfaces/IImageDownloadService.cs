namespace Goreu.Firma.Services.Interfaces
{
    public interface IImageDownloadService
    {
        string GetImagePath();
        bool ImageExists(string imagePath);
        Task<byte[]> GetImageBytesAsync(string imagePath);
    }
}
