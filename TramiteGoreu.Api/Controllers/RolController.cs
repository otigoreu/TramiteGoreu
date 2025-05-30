using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Goreu.Tramite.Api.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolController:ControllerBase
    {

        private readonly IRolService service;

        public RolController(IRolService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await service.GetAsync();
            return response.Success ? Ok(response) : BadRequest(response); 
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RolRequestDto rolRequestDto)
        {
            var response = await service.AddSync(rolRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id, RolRequestDto rolRequestDto)
        {
            var response = await service.UpdateAsync(id, rolRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
