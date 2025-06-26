using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Services.Interface;
using Microsoft.Extensions.Logging;

namespace Goreu.Tramite.Services.Iplementation
{
    public class UnidadOrganicaService : IUnidadOrganicaService
    {
        private readonly IUnidadOrganicaRepository repository;
        private readonly ILogger<UnidadOrganicaService> logger;
        private readonly IMapper mapper;

        public UnidadOrganicaService(IUnidadOrganicaRepository repository, ILogger<UnidadOrganicaService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<UnidadOrganicaResponseDto>>> GetAsync(string descripcion, PaginationDto pagination)
        {
            var response = new BaseResponseGeneric<ICollection<UnidadOrganicaResponseDto>>();
            try
            {
                var data = await repository.GetAsync(
                    predicate: s => s.Descripcion.Contains(descripcion ?? string.Empty),
                    orderBy: x => x.Descripcion,
                    pagination);

                response.Data = mapper.Map<ICollection<UnidadOrganicaResponseDto>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al filtrar las unidades organicas por descripción.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
    }

}
