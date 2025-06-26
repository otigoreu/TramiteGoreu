namespace Goreu.Tramite.Repositories.Implementacion
{
    public class EntidadRepository : RepositoryBase<Entidad>, IEntidadRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public EntidadRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ICollection<Entidad>> GetAsync<TKey>(Expression<Func<Entidad, bool>> predicate, Expression<Func<Entidad, TKey>> orderBy, PaginationDto pagination)
        {
            var queryable = context.Set<Entidad>()

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
