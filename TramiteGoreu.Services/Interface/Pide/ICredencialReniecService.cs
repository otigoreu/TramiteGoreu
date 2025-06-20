using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Request.Pide.Credenciales;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Dto.Response.Pide.Credenciales;
using Goreu.Tramite.Entities.info;

namespace Goreu.Tramite.Services.Interface
{
    public interface ICredencialReniecService
    {
        Task<BaseResponseGeneric<int>> AddAsync(AddCredencialReniecRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, AddCredencialReniecRequestDto request);
        Task<BaseResponseGeneric<ICollection<CredencialReniecResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<CredencialReniecResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<ICollection<CredencialReniecInfo>>> GetAsync(string? descripcion);
        Task<BaseResponseGeneric<CredencialReniecInfo>> GetByNumdocAsync(string nuDniUsuario);
        Task<BaseResponse> FinalizedAsync(int id);
        Task<BaseResponse> InitializedAsync(int id);
    }
}
