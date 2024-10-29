using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;

namespace TramiteGoreu.Services.Interface
{
    public interface IUserService
    {
        Task<BaseResponseGeneric<RegisterResponseDto>> RegisterAsync(RegisterRequestDto request);
        Task<BaseResponseGeneric<LoginResponseDto>> LoginAsync(LoginRequestDto request);
        //-----------------------------------------------------------------------------------------
        Task<BaseResponse> RequestTokenToResetPasswordAsync(ResetPasswordRequestDto request);
        Task<BaseResponse> ResetPasswordAsync(NewPasswordRequestDto request);
        Task<BaseResponse> ChangePasswordAsync(string email, ChangePasswordRequestDto request);
        //--------------------------------------------------------------------------------------------
        Task<BaseResponseGeneric<List<UsuarioResponseDto>>> GetUsersByRole(string? role);
        Task<BaseResponseGeneric<UsuarioResponseDto>> GetUserByEmail(string email);
        Task<BaseResponse> CreateRoleAsync(string roleName);
        Task<BaseResponse> DeleteRoleAsync(string roleName);
        Task<BaseResponseGeneric<List<RoleResponseDto>>> GetRolesAsync();
        Task<BaseResponse> GrantUserRole(string userId, string roleName);
        Task<BaseResponse> GrantUserRoleByEmail(string email, string roleName);
        Task<BaseResponse> RevokeUserRoles(string userId);
        Task<BaseResponse> RevokeUserRole(string userId, string roleName);

    }
}
