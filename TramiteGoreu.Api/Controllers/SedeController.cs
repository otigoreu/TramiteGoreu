using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goreu.Tramite.Api.Controllers
{
    [ApiController]
    [Route("api/sedes")]
    public class SedeController : ControllerBase
    {
        private readonly ISedeService service;

        public SedeController(ISedeService service)
        {
            this.service = service;
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
        public async Task<IActionResult> Post(SedeRequestDto sedeRequestDto)
        {
            var response = await service.AddAsync(sedeRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, SedeRequestDto sedeRequestDto)
        {
            var response = await service.UpdateAsync(id, sedeRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

    }
}
