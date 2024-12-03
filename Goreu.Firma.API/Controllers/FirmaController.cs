using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Goreu.Firma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        // Lee la ruta de la carpeta compartida desde appsettings.json
        private readonly string sharedFolderPath;

        public FirmaController(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;

            // Asigna la ruta desde appsettings.json
            sharedFolderPath = _configuration["FilePaths:SharedFolderPath"];
        }

        [HttpPost("param")]
        public async Task<IActionResult> Post([FromForm] string param_token)
        {
            try
            {
                if (string.IsNullOrEmpty(param_token))
                {
                    return BadRequest(new { message = "Los parámetros no son válidos." });
                }

                //--------------------------------------------
                var filePath = Path.Combine(sharedFolderPath, $"{param_token}.pdf");
                var fileName = $"{param_token}.pdf";

                // Asegúrate de que este controlador permita la descarga de archivos
                var documentToSignUrl = Url.Action("DownloadFile", "FileUpdate", new { fileName = fileName }, Request.Scheme);

                // Validación de la existencia del archivo antes de proceder
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound(new { message = "El archivo no existe en la ubicación especificada." });
                }
                //--------------------------------------------


                PDdESRequest pDdESResponseRequest = new PDdESRequest();

                // Actualizar los campos en la instancia existente
                pDdESResponseRequest.documentToSign = documentToSignUrl;
                pDdESResponseRequest.imageToStamp = _configuration["ServiceUrls:ImageToStamp"];
                pDdESResponseRequest.uploadDocumentSigned = string.Format(_configuration["ServiceUrls:UploadDocumentSigned"], param_token);

                // Leer la configuración
                var config = _tokenService.LoadAuthorizationConfig();
                pDdESResponseRequest.token = await _tokenService.GenerateTokenAsync(config);

                // Serializar a JSON y convertir a Base64
                var json = System.Text.Json.JsonSerializer.Serialize(pDdESResponseRequest);
                var base64EncodedJson = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json));

                return Ok(base64EncodedJson);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = $"Error al obtener el token: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error inesperado: {ex.Message}" });
            }
        }
    }
}
