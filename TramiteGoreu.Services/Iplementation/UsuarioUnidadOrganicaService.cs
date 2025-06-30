namespace Goreu.Tramite.Services.Iplementation
{
    public class UsuarioUnidadOrganicaService : ServiceBase<UsuarioUnidadOrganica, UsuarioUnidadOrganicaRequestDto, UsuarioUnidadOrganicaResponseDto>, IUsuarioUnidadOrganicaService
    {
        private readonly IUsuarioUnidadOrganicaRepository repository;

        public UsuarioUnidadOrganicaService(IUsuarioUnidadOrganicaRepository repository, ILogger<UsuarioUnidadOrganicaService> logger, IMapper mapper) : base(repository, logger, mapper)
        {
            this.repository = repository; // ✅ Asignación correcta
        }

        public async Task<BaseResponseGeneric<ICollection<UsuarioUnidadOrganicaResponseDto>>> GetAsync(int idUnidadOrganica, PaginationDto pagination)
        {
            var response = new BaseResponseGeneric<ICollection<UsuarioUnidadOrganicaResponseDto>>();
            try
            {
                var data = await repository.GetAsync(
                    predicate: s => s.IdUnidadOrganica == idUnidadOrganica,
                    orderBy: x => x.Id,
                    pagination);

                response.Data = mapper.Map<ICollection<UsuarioUnidadOrganicaResponseDto>>(data);
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
