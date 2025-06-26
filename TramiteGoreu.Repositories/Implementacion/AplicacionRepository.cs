namespace Goreu.Tramite.Repositories.Implementacion
{
    public class AplicacionRepository : RepositoryBase<Aplicacion>, IAplicacionRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AplicacionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ICollection<Aplicacion>> GetAsync<TKey>(Expression<Func<Aplicacion, bool>> predicate, Expression<Func<Aplicacion, TKey>> orderBy, PaginationDto pagination)
        {
            var queryable = context.Set<Aplicacion>()

                .Where(predicate)
                .OrderBy(orderBy)
                .AsNoTracking()
                .AsQueryable();

            await httpContextAccessor.HttpContext.InsertarPaginacionHeader(queryable);
            var response = await queryable.Paginate(pagination).ToListAsync();

            return response;
        }
    }
}
