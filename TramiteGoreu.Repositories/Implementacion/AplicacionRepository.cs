using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class AplicacionRepository : RepositoryBase<Aplicacion>, IAplicacionRepository
    {
        private readonly IHttpContextAccessor httpContext;

        public AplicacionRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }

        public async Task FinalizedAsync(int id)
        {
            var aplicacion = await GetAsync(id);
            if (aplicacion is not null) {
                aplicacion.Status = false;
                await UpdateAsync();
            }
        }

        public async Task<ICollection<AplicacionInfo>> GetAsync(string? descripcion)
        {
            var queryable = context.Set<Aplicacion>()
               .Where(x => x.Descripcion.Contains(descripcion ?? string.Empty))
               .IgnoreQueryFilters()
               .AsNoTracking()
               .Select(x => new AplicacionInfo
               {
                   Id = x.Id,
                   Descripcion = x.Descripcion,
                   status = x.Status

               }).AsQueryable();

            await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
            return await queryable.ToListAsync();
        }

        public async Task InitializedAsync(int id)
        {
            var aplicacion = await context.Set<Aplicacion>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (aplicacion is not null)
            {
                aplicacion.Status = true;
                context.Set<Aplicacion>().Update(aplicacion);
                await context.SaveChangesAsync();

            }
        }

    }
}
