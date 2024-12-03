

using Microsoft.Extensions.Configuration;

namespace Goreu.Firma.Services.Implementations
{
    public class FileDownloadService : IFileDownloadService
    {
        private readonly string sharedFolderPathSign;
        private readonly string sharedFolderPath;

        public FileDownloadService(IConfiguration _configuration)
        {
            // Asigna la ruta desde appsettings.json
            sharedFolderPathSign = _configuration["FilePaths:SharedFolderPathSign"];
            sharedFolderPath = _configuration["FilePaths:SharedFolderPath"];
        }

        public async Task<FileDownloadResponse> DownloadDocumentAsync(FileDownloadRequest request)
        {
            // Validar parámetros
            if (string.IsNullOrEmpty(request.FileName))
            {
                throw new ArgumentException("El nombre del archivo no puede estar vacío.");
            }

            // Combinar la ruta
            var filePath = Path.Combine(request.Sign ? sharedFolderPathSign : sharedFolderPath, request.FileName);

            // Verificar si el archivo existe
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Archivo no encontrado.", request.FileName);
            }

            // Leer el archivo
            var fileBytes = await File.ReadAllBytesAsync(filePath);

            return new FileDownloadResponse
            {
                Bytes = fileBytes,
                FileName = request.FileName,
                ContentType = request.FileType
            };
        }
    }
}
