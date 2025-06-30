namespace Goreu.Tramite.Repositories.Implementacion
{
    public class UsuarioUnidadOrganicaRepository : RepositoryBase<UsuarioUnidadOrganica>, IUsuarioUnidadOrganicaRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsuarioUnidadOrganicaRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ICollection<UsuarioUnidadOrganica>> GetAsync<TKey>(Expression<Func<UsuarioUnidadOrganica, bool>> predicate, Expression<Func<UsuarioUnidadOrganica, TKey>> orderBy, PaginationDto pagination)
        {
            var queryable = context.Set<UsuarioUnidadOrganica>()
                .Include(x => x.Usuario)
                .Include(x => x.UnidadOrganica)

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
