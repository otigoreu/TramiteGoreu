namespace Goreu.Tramite.Repositories.Implementacion
{
    public class HistorialRepository : RepositoryBase<Historial>, IHistorialRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HistorialRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
    }
}
