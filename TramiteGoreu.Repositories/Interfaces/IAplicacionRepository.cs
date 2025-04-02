using Goreu.Tramite.Entities.info;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IAplicacionRepository : IRepositoryBase<Aplicacion>
    {
        Task<ICollection<AplicacionInfo>> GetAsync(string? descripcion);
        Task FinalizedAsync(int id);
        Task InitializedAsync(int id);
    }
}
