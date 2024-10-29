using Microsoft.AspNetCore.Http;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence;

namespace TramiteGoreu.Repositories.Implementacion
{
    public class AplicacionRepository : RepositoryBase<Aplicacion>, IAplicacionRepository
    {
       

        public AplicacionRepository(ApplicationDbContext context ): base(context)
        {
            
        }


    }
}
