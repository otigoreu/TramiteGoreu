namespace Goreu.Firma.Dto.Requests
{
    public class FileUpdateRequest
    {
        public int Id { get; set; }
        public IFormFile SignedFile { get; set; }
    }
}
