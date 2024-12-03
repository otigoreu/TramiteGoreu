namespace Goreu.Firma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FileDownloadController : Controller
    {
        private readonly IFileDownloadService _fileDownloadService;

        public FileDownloadController(IFileDownloadService fileDownloadService)
        {
            _fileDownloadService = fileDownloadService;
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadDocument([FromQuery] FileDownloadRequest request)
        {
            try
            {
                var fileResult = await _fileDownloadService.DownloadDocumentAsync(request);

                return File(fileResult.Bytes, fileResult.ContentType, fileResult.FileName);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al descargar el documento: {ex.Message}");
            }
        }
    }
}
