namespace Goreu.Tramite.Services.Iplementation
{
    public class HistorialService : ServiceBase<Historial, HistorialRequestDto, HistorialResponseDto>, IHistorialService 
    {
        private readonly IHistorialRepository repository;

        public HistorialService(IHistorialRepository repository, ILogger<HistorialService> logger, IMapper mapper) : base(repository, logger, mapper)
        {
            this.repository = repository; // ✅ Asignación correcta
        }
    }
}
