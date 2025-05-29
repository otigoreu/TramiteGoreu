using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;

namespace Goreu.Tramite.Services.Interface
{
    public interface IRolService
    {
        Task<BaseResponseGeneric<string>> AddSync(RolRequestDto request);
        Task<BaseResponse> DeleteAsync(string id);
        Task<BaseResponse> UpdateAsync(string id, RolRequestDto request);
        Task<BaseResponseGeneric<ICollection<RolResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<RolResponseDto>> GetAsync(string id);

    }
}
