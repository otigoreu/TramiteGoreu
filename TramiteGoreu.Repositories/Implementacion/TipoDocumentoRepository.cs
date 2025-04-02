using Goreu.Tramite.Entities;
using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class TipoDocumentoRepository : RepositoryBase<TipoDocumento>, ITipoDocumentoRepository
    {
        private readonly IHttpContextAccessor httpContext;

        public TipoDocumentoRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }

        public async Task FinalizedAsync(int id)
        {
            var tipoDocu= await GetAsync(id);
            if (tipoDocu is not  null)
            {
                tipoDocu.Status = false;
                await UpdateAsync();
            }
        }

        public async Task<ICollection<TipoDocumentoInfo>> GetAsync(string? descripcion)
        {
            //eager loading optimizado
            var queryable = context.Set<TipoDocumento>()
                .Where(x => x.Descripcion.Contains(descripcion ?? string.Empty))
                .IgnoreQueryFilters()
                .AsNoTracking()
                .Select(x => new TipoDocumentoInfo
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Abrev = x.Abrev,
                    status = x.Status

                }).AsQueryable();

            await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
            return await queryable.ToListAsync();
        }

        public async Task InitializedAsync(int id)
        {

            var tipoDocu = await context.Set<TipoDocumento>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
           
            if (tipoDocu is not null)
            {
                tipoDocu.Status = true;
                context.Set<TipoDocumento>().Update(tipoDocu);
                await context.SaveChangesAsync();

            }

        }
    }
}
