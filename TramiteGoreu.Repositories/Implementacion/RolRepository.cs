using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence.Migrations;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class RolRepository : IRolRepository
    {

        private readonly IHttpContextAccessor httpContext;
        private readonly DbContext context;

        public RolRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) 
        {
            this.httpContext = httpContext;
            this.context = context;
        }

        public async Task<Role?> GetAsync(string id)
        {
            return await context.Set<Role>().FindAsync(id);
        }


        public async Task<string> AddAsync(Role rol)
        {
            await context.Set<Role>().AddAsync(rol);
            await context.SaveChangesAsync();
            return rol.Id;
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            return await context.Set<Role>().AsNoTracking().ToListAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var item = await context.Set<Role>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (item is not null)
            {
                context.Set<Role>().Remove(item);
                await context.SaveChangesAsync();
            }
            else
                throw new InvalidOperationException($"No se encontro el registro con id {id}");
        }

        public async Task FinalizedAsync(string id)
        {
            var rol = await GetAsync(id);
            if (rol is not null)
            {
                rol.Status = false;
                await context.SaveChangesAsync();
            }
        }

        public async Task InitializedAsync(string id)
        {
            var rol = await context.Set<Role>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (rol is not null)
            {
                rol.Status = true;
                context.Set<Role>().Update(rol);
                await context.SaveChangesAsync();

            }
        }
    }
}
