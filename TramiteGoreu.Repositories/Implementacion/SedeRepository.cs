using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence;

namespace TramiteGoreu.Repositories.Implementacion
{
    public class SedeRepository : RepositoryBase<Sede>, ISedeRepository
    {
        public SedeRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
