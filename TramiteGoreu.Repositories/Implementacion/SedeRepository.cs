using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class SedeRepository : RepositoryBase<Sede>, ISedeRepository
    {
        private readonly IHttpContextAccessor httpContext;
        public SedeRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }

        public async Task FinalizedAsync(int id)
        {
            var sede = await GetAsync(id);
            if (sede is not null)
            {
                sede.Status = false;
                await UpdateAsync();
            }
        }

        public async Task<ICollection<SedeInfo>> GetAsync(string? descripcion)
        {
            //eager loading optimizado
            var queryable = context.Set<Sede>()
                .Where(x => x.Descripcion.Contains(descripcion ?? string.Empty))
                .IgnoreQueryFilters()
                .AsNoTracking()
                .Select(x => new SedeInfo
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
            var sede = await context.Set<Sede>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (sede is not null)
            {
                sede.Status = true;
                context.Set<Sede>().Update(sede);
                await context.SaveChangesAsync();

            }
        }
    }
}
