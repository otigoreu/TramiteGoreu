using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;
using TramiteGoreu.Persistence;
using TramiteGoreu.Repositories.Utils;

namespace TramiteGoreu.Repositories
{
    public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
    {
        private readonly IHttpContextAccessor httpContext;

        public PersonaRepository(ApplicationDbContext context, IHttpContextAccessor httpContext): base (context)
        {
            this.httpContext = httpContext;
        }
        public async Task<ICollection<PersonaInfo>> GetAsync(string? nombres, PaginationDto pagination)
        {
            //eager loading optimizado
            var queryable = context.Set<Persona>()
                .Where(x => x.nombres.Contains(nombres ?? string.Empty))
                .AsNoTracking()
                .Select(x => new PersonaInfo
                {
                    Id = x.Id,
                    nombres = x.nombres,
                    apellidos = x.apellidos,
                    fechaNac = x.fechaNac.ToShortDateString(),
                    direccion = x.direccion,
                    referencia = x.referencia,
                    celular=x.celular,
                    edad=x.edad,
                    email = x.email,
                    tipoDoc = x.tipoDoc,
                    nroDoc = x.nroDoc,
                    status = x.Status ? "Activo" : "Inactivo"

                }).AsQueryable();

            await httpContext.HttpContext.InsertarPaginacionHeader(queryable);
            return await queryable.OrderBy(x => x.Id).Paginate(pagination).ToListAsync();

        }
        public async Task FinalizedAsync(int id)
        {
            var person = await GetAsync(id);
            if (person is not null)
            {
                person.Status=true;
                await UpdateAsync();
            }
        }
        

    }
}
