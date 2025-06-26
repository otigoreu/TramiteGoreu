using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Goreu.Tramite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadOrganicaController : ControllerBase
    {
        private readonly IUnidadOrganicaService service;

        public UnidadOrganicaController(IUnidadOrganicaService _service)
        {
            this.service = _service;
        }

        [HttpGet("descripcion")]
        public async Task<IActionResult> Get([FromQuery] string? search, [FromQuery] PaginationDto pagination)
        {
            var result = await service.GetAsync(search ?? string.Empty, pagination);

            return result.Success ? Ok(result) : StatusCode(500, result.ErrorMessage);
        }
    }
}
