using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Entities.info;

namespace Goreu.Tramite.Services.Interface
{
    public interface ISedeService
    {
        Task<BaseResponseGeneric<int>> AddAsync(SedeRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, SedeRequestDto request);
        Task<BaseResponseGeneric<ICollection<SedeResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<SedeResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<ICollection<SedeInfo>>> GetAsync(string? descripcion);
        Task<BaseResponse> FinalizedAsync(int id);
        Task<BaseResponse> InitializedAsync(int id);
    }
}
