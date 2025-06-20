using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace Goreu.Tramite.Repositories.Implementacion
{
    //public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
    //{
    //    private readonly IHttpContextAccessor httpContext;

    //    public PersonaRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
    //    {
    //        this.httpContext = httpContext;
    //    }

    //    public async Task<ICollection<PersonaInfo>> GetAsync(string? nombres, PaginationDto pagination)
    //    {
    //        //eager loading optimizado
    //        var queryable = context.Set<Persona>()
    //            .Where(x => x.Nombres.Contains(nombres ?? string.Empty))
    //            .AsNoTracking()
    //            .Select(x => new PersonaInfo
    //            {
    //                Id = x.Id,
    //                nombres = x.Nombres,
    //                apellidoPat = x.ApellidoPat,
    //                apellidoMat = x.ApellidoMat,
    //                fechaNac = x.FechaNac,
    //                email = x.Email,
    //                idTipoDoc = x.IdTipoDoc,
    //                nroDoc = x.NroDoc,
    //                status = x.Status

    //            }).AsQueryable();

    //        await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
    //        return await queryable.OrderBy(x => x.Id).Paginate(pagination).ToListAsync();

    //    }

    //    public async Task<ICollection<PersonaInfo>> GetAsyncfilter(string? nombres, PaginationDto pagination)
    //    {
    //        //eager loading optimizado
    //        var queryable = context.Set<Persona>()
    //            .Where(x => x.Nombres.Contains(nombres ?? string.Empty))
    //            .IgnoreQueryFilters()
    //            .AsNoTracking()
    //            .Select(x => new PersonaInfo
    //            {
    //                Id = x.Id,
    //                nombres = x.Nombres,
    //                apellidoPat = x.ApellidoPat,
    //                apellidoMat = x.ApellidoMat,
    //                fechaNac = x.FechaNac,
    //                email = x.Email,
    //                idTipoDoc = x.IdTipoDoc,
    //                nroDoc = x.NroDoc,
    //                status = x.Status

    //            }).AsQueryable();

    //        await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
    //        return await queryable.OrderBy(x => x.Id).Paginate(pagination).ToListAsync();
    //    }

    //    public async Task<ICollection<PersonaInfo>> GetAsyncEmail(string? email, PaginationDto pagination)
    //    {
    //        //eager loading optimizado
    //        var queryable = context.Set<Persona>()
    //            .Where(x => x.Email.Contains(email ?? string.Empty))
    //            .AsNoTracking()
    //            .Select(x => new PersonaInfo
    //            {
    //                Id = x.Id,
    //                nombres = x.Nombres,
    //                apellidoPat = x.ApellidoPat,
    //                apellidoMat = x.ApellidoMat,
    //                fechaNac = x.FechaNac,
    //                email = x.Email,
    //                idTipoDoc = x.IdTipoDoc,
    //                nroDoc = x.NroDoc,
    //                status = x.Status 

    //            }).AsQueryable();

    //        await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
    //        return await queryable.OrderBy(x => x.Id).Paginate(pagination).ToListAsync();

    //    }
        
    //    public async Task<Persona> GetAsyncNumdoc(string numdoc)
    //    {
    //        var persona = await context.Set<Persona>()
    //           .AsNoTracking()
    //           .Where(x => x.NroDoc == numdoc)
    //           .FirstOrDefaultAsync();

    //        if (persona == null) return persona;

    //        context.Set<Persona>().Entry(persona).State = EntityState.Detached;
    //        return persona;
    //    }

    //    public async Task FinalizedAsync(int id)
    //    {
    //        var person = await GetAsync(id);
    //        if (person is not null)
    //        {
    //            person.Status = false;
    //            await UpdateAsync();
    //        }
    //    }

    //    public async Task InitializedAsync(int id)
    //    {
    //        var person = await context.Set<Persona>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    //        if (person is not null)
    //        {
    //            person.Status = true;
    //            context.Set<Persona>().Update(person);
    //            await context.SaveChangesAsync();

    //        }
    //    }
    //}
}
