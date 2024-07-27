using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;
using TramiteGoreu.Persistence;

namespace TramiteGoreu.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context): base (context)
        {
      
        }
        public async Task<ICollection<PersonInfo>> GetAsync(string? nombres)
        { 
            //eager loading optimizado
            return await context.Set<Person>()
                .Where(x => x.nombres.Contains(nombres ?? string.Empty))
                .AsNoTracking()
                .Select(x => new PersonInfo
                {
                    Id= x.Id,
                    nombres= x.nombres,
                    apellidos= x.apellidos,
                    fechaNac=x.fechaNac.ToShortDateString(),
                    direccion=x.direccion,
                    referencia=x.referencia,
                    email=x.email,
                    tipoDoc=x.tipoDoc,
                    nroDoc=x.nroDoc,
                    status=x.Status ? "Activo":"Inactivo"

                }).ToListAsync();
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
