using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;

namespace TramiteGoreu.Services.Interface
{
    public interface IUserService
    {
        Task<BaseResponseGeneric<RegisterResponseDto>> RegisterAsync(RegisterRequestDto request);
        Task<BaseResponseGeneric<LoginResponseDto>> LoginAsync(LoginRequestDto request);
        Task<BaseResponse> RequestTokenToResetPasswordAsync(ResetPasswordRequestDto request);
    }
}
