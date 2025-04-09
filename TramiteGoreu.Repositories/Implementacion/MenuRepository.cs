using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        private readonly IHttpContextAccessor httpContext;
        public MenuRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
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

      
        public async Task<ICollection<MenuInfo>> GetAsync(string? displayName)
        {
            var queryable = context.Set<Menu>()
               .Include(x=>x.Aplicacion)
               .Where(x => x.DisplayName.Contains(displayName ?? string.Empty))
               .IgnoreQueryFilters()
               .AsNoTracking()
               .Select(x => new MenuInfo
               {
                   Id = x.Id,
                   DisplayName = x.DisplayName,
                   IconName=x.IconName,
                   Route=x.Route,
                   AplicacionId=x.Aplicacion.Id,
                   Aplicacion=x.Aplicacion.Descripcion,
                   ParentMenuId=x.ParentMenuId,
                   status = x.Status

               }).AsQueryable();

            await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
            return await queryable.ToListAsync();
        }


        public async Task InitializedAsync(int id)
        {
            var menu = await context.Set<Menu>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (menu is not null)
            {
                menu.Status = true;
                context.Set<Menu>().Update(menu);
                await context.SaveChangesAsync();

            }
        }
        public async Task FinalizedAsync(int id)
        {
            var menu = await GetAsync(id);
            if (menu is not null)
            {
                menu.Status = false;
                await UpdateAsync();
            }
        }

    }
}
