namespace Goreu.Firma.Services.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadDocumentSignedAsync(string id, IFormFile signedFile);
    }
}
