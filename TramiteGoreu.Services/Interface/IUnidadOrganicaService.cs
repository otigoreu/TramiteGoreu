using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Repositories.Interfaces;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.Interface
{
    public interface IUnidadOrganicaService
    {
        Task<BaseResponseGeneric<int>> AddAsync(UnidadOrganicaRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, UnidadOrganicaRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizeAsync(int id);
        Task<BaseResponse> InitializeAsync(int id);
        Task<BaseResponseGeneric<UnidadOrganicaResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<ICollection<UnidadOrganicaResponseDto>>> GetAsync(string descripcion, PaginationDto pagination);
    }
}

