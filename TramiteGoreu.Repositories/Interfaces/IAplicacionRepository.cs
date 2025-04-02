using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IAplicacionRepository : IRepositoryBase<Aplicacion>
    {
        Task FinalizedAsync(int id);
        Task InitializedAsync(int id);
    }
}
