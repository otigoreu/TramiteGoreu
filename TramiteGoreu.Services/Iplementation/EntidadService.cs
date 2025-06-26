namespace Goreu.Tramite.Services.Iplementation
{
    public class EntidadService : BaseService<Entidad, EntidadRequestDto, EntidadResponseDto>, IEntidadService 
    {
        private readonly IEntidadRepository repository;

        public EntidadService(IEntidadRepository repository, ILogger<EntidadService> logger, IMapper mapper) : base(repository, logger, mapper)
        {
            this.repository = repository; // ✅ Asignación correcta
        }

        public async Task<BaseResponseGeneric<ICollection<EntidadResponseDto>>> GetAsync(string descripcion, PaginationDto pagination)
        {
            var response = new BaseResponseGeneric<ICollection<EntidadResponseDto>>();
            try
            {
                var data = await repository.GetAsync(
                    predicate: s => s.Descripcion.Contains(descripcion ?? string.Empty),
                    orderBy: x => x.Descripcion,
                    pagination);

                response.Data = mapper.Map<ICollection<EntidadResponseDto>>(data);
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
