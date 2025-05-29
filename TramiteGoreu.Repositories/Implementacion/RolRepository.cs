using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence.Migrations;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class RolRepository : IRolRepository
    {

        protected readonly DbContext context;

        public RolRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task<Rol?> GetAsync(string id)
        {
            return await context.Set<Rol>().FindAsync(id);
        }


        public async Task<string> AddAsync(Rol rol)
        {
            await context.Set<Rol>().AddAsync(rol);
            await context.SaveChangesAsync();
            return rol.Id;
        }

        public async Task<ICollection<Rol>> GetAsync()
        {
            return await context.Set<Rol>().AsNoTracking().ToListAsync();
        }
    }
}
