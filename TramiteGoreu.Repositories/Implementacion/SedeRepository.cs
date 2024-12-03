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
    }
}
