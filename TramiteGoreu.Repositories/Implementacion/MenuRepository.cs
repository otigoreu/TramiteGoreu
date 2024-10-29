using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence;

namespace TramiteGoreu.Repositories.Implementacion
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Menu>> GetByIdAplicationAsync(int idAplication)
        {
            return await context.Set<Menu>().Include(x => x.MenuRoles)
               .Where(x => x.IdAplicacion == idAplication)
               .ToListAsync();
        }

        public async Task<List<Menu>> GetMenusByApplicationAndRolesAsync(int applicationId, List<string> roleIds)
        {
            return await context.Set<Menu>()
               .Where(menu => menu.IdAplicacion == applicationId &&
                              menu.MenuRoles.Any(mr => roleIds.Contains(mr.IdRol)))
               .ToListAsync();
        }
    }
}
