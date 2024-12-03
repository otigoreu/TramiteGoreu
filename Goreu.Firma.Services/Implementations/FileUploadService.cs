using Goreu.Firma.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Firma.Services.Implementations
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string sharedFolderPathSign;

        public FileUploadService(IConfiguration _configuration)
        {
            // Asigna la ruta desde appsettings.json
            sharedFolderPathSign = _configuration["FilePaths:SharedFolderPathSign"];
        }


        public async Task<string> UploadDocumentSignedAsync(string id, IFormFile signedFile)
        {
            if (signedFile == null || signedFile.Length == 0)
            {
                throw new ArgumentException("No se proporcionó un archivo válido.");
            }

            // Asegurarse de que el directorio exista
            if (!Directory.Exists(sharedFolderPathSign))
            {
                Directory.CreateDirectory(sharedFolderPathSign);
            }

            var filePath = Path.Combine(sharedFolderPathSign, $"{id}.pdf");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await signedFile.CopyToAsync(stream);
            }

            // Retorna un mensaje según el tipo de archivo
            return Path.GetExtension(signedFile.FileName).ToLower() == ".7z"
                ? "Archivo .7z recibido y procesado."
                : $"Archivo firmado {signedFile.FileName} recibido correctamente. ID de documento: {id}";
        }
    }
}
