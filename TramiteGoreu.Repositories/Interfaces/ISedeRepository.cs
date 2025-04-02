using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface ISedeRepository : IRepositoryBase<Sede>
    {
        Task FinalizedAsync(int id);
        Task InitializedAsync(int id);
    }
}
