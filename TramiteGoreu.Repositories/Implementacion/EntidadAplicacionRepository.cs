namespace Goreu.Tramite.Repositories.Implementacion
{
    public class EntidadAplicacionRepository : RepositoryBase<EntidadAplicacion>, IEntidadAplicacionRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public EntidadAplicacionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ICollection<EntidadAplicacion>> GetAsync<TKey>(Expression<Func<EntidadAplicacion, bool>> predicate, Expression<Func<EntidadAplicacion, TKey>> orderBy, PaginationDto pagination)
        {
            var queryable = context.Set<EntidadAplicacion>()

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
