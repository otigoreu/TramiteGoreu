using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;

namespace TramiteGoreu.Services.Interface
{
    public interface ISedeService
    {
        Task<BaseResponseGeneric<int>> AddAsync(SedeRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, SedeRequestDto request);
        Task<BaseResponseGeneric<ICollection<SedeResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<SedeResponseDto>> GetAsync(int id);
    }
}
