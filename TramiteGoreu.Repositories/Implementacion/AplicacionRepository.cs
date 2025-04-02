using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class AplicacionRepository : RepositoryBase<Aplicacion>, IAplicacionRepository
    {


        public AplicacionRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task FinalizedAsync(int id)
        {
            var aplicacion = await GetAsync(id);
            if (aplicacion is not null) {
                aplicacion.Status = false;
                await UpdateAsync();
            }
        }

        public async Task InitializedAsync(int id)
        {
            var aplicacion = await context.Set<Aplicacion>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (aplicacion is not null)
            {
                aplicacion.Status = true;
                context.Set<Aplicacion>().Update(aplicacion);
                await context.SaveChangesAsync();

            }
        }
    }
}
