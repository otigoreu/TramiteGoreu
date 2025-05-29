using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Usuario?> GetAsync(string id)
        {
            return await context.Set<Usuario>().Include(x => x.UsuarioAplicaciones).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
