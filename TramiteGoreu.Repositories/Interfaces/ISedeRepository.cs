using Goreu.Tramite.Entities.info;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface ISedeRepository : IRepositoryBase<UnidadOrganica>
    {
        Task<ICollection<SedeInfo>> GetAsync(string? descripcion);
        Task FinalizedAsync(int id);
        Task InitializedAsync(int id);
    }
}
