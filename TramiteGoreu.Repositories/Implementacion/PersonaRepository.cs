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
    public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
    {
        private readonly IHttpContextAccessor httpContext;

        public PersonaRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }
        public async Task<ICollection<PersonaInfo>> GetAsync(string? nombres, PaginationDto pagination)
        {
            //eager loading optimizado
            var queryable = context.Set<Persona>()
                .Where(x => x.Nombres.Contains(nombres ?? string.Empty))
                .AsNoTracking()
                .Select(x => new PersonaInfo
                {
                    Id = x.Id,
                    nombres = x.Nombres,
                    apellidos = x.Apellidos,
                    fechaNac = x.FechaNac,
                    direccion = x.Direccion,
                    referencia = x.Referencia,
                    celular = x.Celular,
                    edad = x.Edad,
                    email = x.Email,
                    tipoDoc = x.TipoDoc,
                    nroDoc = x.NroDoc,
                    status = x.Status

                }).AsQueryable();

            await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
            return await queryable.OrderBy(x => x.Id).Paginate(pagination).ToListAsync();

        }
        public async Task<ICollection<PersonaInfo>> GetAsyncEmail(string? email, PaginationDto pagination)
        {
            //eager loading optimizado
            var queryable = context.Set<Persona>()
                .Where(x => x.Email.Contains(email ?? string.Empty))
                .AsNoTracking()
                .Select(x => new PersonaInfo
                {
                    Id = x.Id,
                    nombres = x.Nombres,
                    apellidos = x.Apellidos,
                    fechaNac = x.FechaNac,
                    direccion = x.Direccion,
                    referencia = x.Referencia,
                    celular = x.Celular,
                    edad = x.Edad,
                    email = x.Email,
                    tipoDoc = x.TipoDoc,
                    nroDoc = x.NroDoc,
                    status = x.Status 

                }).AsQueryable();

            await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
            return await queryable.OrderBy(x => x.Id).Paginate(pagination).ToListAsync();

        }
        public async Task FinalizedAsync(int id)
        {
            var person = await GetAsync(id);
            if (person is not null)
            {
                person.Status = true;
                await UpdateAsync();
            }
        }


    }
}
