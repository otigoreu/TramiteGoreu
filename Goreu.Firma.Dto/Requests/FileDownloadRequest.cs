namespace Goreu.Firma.Dto.Requests
{
    public class FileDownloadRequest
    {
        public string FileName { get; set; } = default;
        public bool Sign { get; set; } = false; // Valor predeterminado
        public string FileType { get; set; } = "application/pdf"; // Valor predeterminado
    }
}
