using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;

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
    }
}
