using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Repositories.Interfaces;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.Interface
{
    public interface IUnidadOrganicaService : IServiceBase<UnidadOrganicaRequestDto, UnidadOrganicaResponseDto>
    {
        Task<BaseResponseGeneric<ICollection<UnidadOrganicaResponseDto>>> GetAsync(string descripcion, PaginationDto pagination);
    }
}

