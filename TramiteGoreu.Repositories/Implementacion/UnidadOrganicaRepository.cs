using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class UnidadOrganicaRepository : RepositoryBase<UnidadOrganica>, IUnidadOrganicaRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UnidadOrganicaRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ICollection<UnidadOrganica>> GetAsync<TKey>(Expression<Func<UnidadOrganica, bool>> predicate, Expression<Func<UnidadOrganica, TKey>> orderBy, PaginationDto pagination)
        {
            var queryable = context.Set<UnidadOrganica>()
                .Include(x => x.Entidad)
                .Include(x => x.Dependencia)
                .Include(x => x.Hijos)

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
