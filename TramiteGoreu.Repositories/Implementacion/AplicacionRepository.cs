using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class AplicacionRepository : RepositoryBase<Aplicacion>, IAplicacionRepository
    {


        public AplicacionRepository(ApplicationDbContext context) : base(context)
        {

        }


    }
}
