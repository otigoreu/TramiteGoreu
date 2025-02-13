using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;

namespace Goreu.Tramite.Services.Interface
{
    public  interface ITipoDocumentoService
    {
        Task<BaseResponseGeneric<ICollection<TipoDocumentoResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<TipoDocumentoResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(TipoDocumentoRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, TipoDocumentoRequestDto resquest);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizedAsync(int id);
        Task<BaseResponse> InitializedAsync(int id);
    }
}
