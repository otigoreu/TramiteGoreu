using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Api.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService service;

        public PersonasController(IPersonaService service)
        {
            this.service = service;
        }

        [HttpGet("nombre")]
       [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(string? nombres, [FromQuery]PaginationDto pagination)
        {
            var response=await service.GetAsync(nombres,pagination);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("email")]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(string? email)
        {
            var response = await service.GetAsyncBYEmail(email);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) 
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonaRequestDto personRequestDto) 
        {
            var response = await service.AddAsync(personRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id,PersonaRequestDto personRequestDto) 
        {
            var response = await service.UpdateAsync(id,personRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id)
        {
            var response = await service.FinalizedAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
