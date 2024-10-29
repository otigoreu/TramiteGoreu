using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService service;

        public MenuController(IMenuService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuRequestDto request)
        {
            var response = await service.AddAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("{idAplication:int}")]
        public async Task<IActionResult> GetByAplication(int idAplication)
        {
            var email = HttpContext.User.Claims.First(p => p.Type == ClaimTypes.Email).Value;
            var response = await service.GetByAplicationAsync(idAplication, email);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
