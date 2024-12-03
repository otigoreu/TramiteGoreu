namespace Goreu.Firma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageDownloadController : ControllerBase
    {
        private readonly IImageDownloadService _imageService;

        public ImageDownloadController(IImageDownloadService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadImageToStamp()
        {
            try
            {
                // Obtener la ruta de la imagen desde el servicio
                var imagePath = _imageService.GetImagePath();

                // Verificar si la imagen existe
                if (!_imageService.ImageExists(imagePath))
                {
                    return NotFound($"La imagen no fue encontrada.");
                }

                // Obtener los bytes de la imagen
                var imageBytes = await _imageService.GetImageBytesAsync(imagePath);

                // Devolver la imagen con la cabecera de tipo PNG
                return File(imageBytes, "image/png", $"stamp.png");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al descargar la imagen: {ex.Message}");
            }
        }
    }
}
