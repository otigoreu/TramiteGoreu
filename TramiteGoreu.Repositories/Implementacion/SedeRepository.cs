using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class SedeRepository : RepositoryBase<Sede>, ISedeRepository
    {
        public SedeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task FinalizedAsync(int id)
        {
            var sede = await GetAsync(id);
            if (sede is not null)
            {
                sede.Status = false;
                await UpdateAsync();
            }
        }

        public async Task InitializedAsync(int id)
        {
            var sede = await context.Set<Sede>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (sede is not null)
            {
                sede.Status = true;
                context.Set<Sede>().Update(sede);
                await context.SaveChangesAsync();

            }
        }
    }
}
