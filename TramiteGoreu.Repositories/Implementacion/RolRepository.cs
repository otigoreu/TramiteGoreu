using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TramiteGoreu.Entities;
//using TramiteGoreu.Persistence.Migrations;

namespace Goreu.Tramite.Repositories.Implementacion
{
    //public class RolRepository : IRolRepository
    //{

    //    private readonly IHttpContextAccessor httpContext;
    //    private readonly DbContext context;

    //    public RolRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) 
    //    {
    //        this.httpContext = httpContext;
    //        this.context = context;
    //    }

    //    public async Task<Rol?> GetAsync(string id)
    //    {
    //        return await context.Set<Rol>().FindAsync(id);
    //    }


    //    public async Task<string> AddAsync(Rol rol)
    //    {
    //        await context.Set<Rol>().AddAsync(rol);
    //        await context.SaveChangesAsync();
    //        return rol.Id;
    //    }

    //    public async Task<ICollection<Rol>> GetAllAsync()
    //    {
    //        return await context.Set<Rol>().AsNoTracking().ToListAsync();
    //    }

    //    public async Task DeleteAsync(string id)
    //    {
    //        var item = await context.Set<Rol>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    //        if (item is not null)
    //        {
    //            context.Set<Rol>().Remove(item);
    //            await context.SaveChangesAsync();
    //        }
    //        else
    //            throw new InvalidOperationException($"No se encontro el registro con id {id}");
    //    }

    //    public async Task FinalizedAsync(string id)
    //    {
    //        var rol = await GetAsync(id);
    //        if (rol is not null)
    //        {
    //            rol.Status = false;
    //            await context.SaveChangesAsync();
    //        }
    //    }

    //    public async Task InitializedAsync(string id)
    //    {
    //        var rol = await context.Set<Rol>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    //        if (rol is not null)
    //        {
    //            rol.Status = true;
    //            context.Set<Rol>().Update(rol);
    //            await context.SaveChangesAsync();

    //        }
    //    }
    //}
}
