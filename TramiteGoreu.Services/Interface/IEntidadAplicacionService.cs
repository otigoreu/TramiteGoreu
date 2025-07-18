using AutoMapper;
using Goreu.Tramite.Services.Iplementation;
using Microsoft.Extensions.Logging;

namespace Goreu.Tramite.Services.Interface
{
    public interface IEntidadAplicacionService : IServiceBase<EntidadAplicacionRequestDto, EntidadAplicacionResponseDto>
    {
        Task<BaseResponseGeneric<ICollection<EntidadAplicacionResponseDto>>> GetAplicacionesConEstadoPorEntidadAsync(int idEntidad, string descripcion, PaginationDto pagination);
        Task<BaseResponseGeneric<EntidadAplicacionResponseDto>> GetAsync(int idEntidad, int idAplicacion);
    }
}
