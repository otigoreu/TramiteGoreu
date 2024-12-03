namespace Goreu.Firma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpdateController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        private readonly string sharedFolderPath;
        private readonly string sharedFolderPathSign;

        public FileUpdateController(IFileUploadService fileUploadService, IConfiguration _configuration)
        {
            _fileUploadService = fileUploadService;

            // Asigna la ruta desde appsettings.json
            sharedFolderPath = _configuration["FilePaths:SharedFolderPath"];
            sharedFolderPathSign = _configuration["FilePaths:SharedFolderPathSign"];
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UploadDocumentSigned(string id, [FromForm] IFormFile signed_file)
        {
            try
            {
                var result = await _fileUploadService.UploadDocumentSignedAsync(id, signed_file);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("upload-pdf")]
        public async Task<IActionResult> UploadPdf(IFormFile pdfFile)
        {
            try
            {
                // Verificar si se recibió el archivo
                if (pdfFile == null || pdfFile.Length == 0)
                    return BadRequest(new { success = false, message = "No se ha seleccionado un archivo." });

                // Crear un nombre de archivo único
                var fileExtension = Path.GetExtension(pdfFile.FileName); // Obtener la extensión del archivo
                var fileName = $"{Guid.NewGuid()}{fileExtension}"; // Combinar GUID con la extensión

                // Componer la ruta completa donde se guardará el archivo
                var filePath = Path.Combine(sharedFolderPath, fileName);

                // Guardar el archivo en la carpeta compartida
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pdfFile.CopyToAsync(stream);
                }

                return Ok(new { success = true, message = "Archivo subido correctamente.", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error al guardar el archivo: {ex.Message}" });
            }
        }

        [HttpGet("files")]
        public IActionResult GetFiles()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(sharedFolderPath);
                var files = directoryInfo.GetFiles().Select(file => new
                {
                    Name = file.Name,
                    Path = file.Name // Puedes devolver solo el nombre si no necesitas la ruta completa
                }).ToList();

                return Ok(files);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error al obtener archivos: {ex.Message}" });
            }
        }

        [HttpGet("filesFirmado")]
        public IActionResult GetFilesFirmado()
        {
            try
            {
                var directoryInfo = new DirectoryInfo(sharedFolderPathSign);
                var files = directoryInfo.GetFiles().Select(file => new
                {
                    Name = file.Name,
                    Path = file.Name // Puedes devolver solo el nombre si no necesitas la ruta completa
                }).ToList();

                return Ok(files);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error al obtener archivos: {ex.Message}" });
            }
        }

        [HttpGet("DownloadFile")]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(sharedFolderPath, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", fileName);
        }
    }
}
