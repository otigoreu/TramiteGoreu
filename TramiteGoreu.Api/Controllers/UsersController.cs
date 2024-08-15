using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] NewPasswordRequestDto request)
        {
            var response = await service.ResetPasswordAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("ChangePassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDto request)
        {
            //Obtener eil del token actual
            var email = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email ).Value;
            var response = await service.ChangePasswordAsync(email, request);
            return response.Success ? Ok(response) : BadRequest(response);
        }


    }
}
