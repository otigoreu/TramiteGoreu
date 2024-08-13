using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var response = await service.RegisterAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await service.LoginAsync(request);
            return response.Success ? Ok(response) : Unauthorized(response);
        }

        [HttpPost("RequestTokenToResetPassword")]
        public async Task<IActionResult> RequestTokenToResetPassword(ResetPasswordRequestDto request)
        {
            var response = await service.RequestTokenToResetPasswordAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

    }
}
