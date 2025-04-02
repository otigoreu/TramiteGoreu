using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Goreu.Tramite.Api.Controllers
{
    [ApiController]
    [Route("api/aplicaciones")]
    public class AplicacionController : ControllerBase
    {
        private readonly IAplicacionService service;

        public AplicacionController(IAplicacionService service)
        {
            this.service = service;
        }
        [HttpGet("descripcion")]
        public async Task<IActionResult> Get(string? descripcion)
        {

            var response = await service.GetAsync(descripcion);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            var response = await service.GetAsync();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AplicacionRequestDto aplicacionRequestDto)
        {
            var response = await service.AddAsync(aplicacionRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, AplicacionRequestDto aplicacionRequestDto)
        {
            var response = await service.UpdateAsync(id, aplicacionRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("finalized/{id:int}")]
        public async Task<IActionResult> PatchFinit(int id)
        {

            var response = await service.FinalizedAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("initialized/{id:int}")]
        public async Task<IActionResult> PatchInit(int id)
        {

            var response = await service.InitializedAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
