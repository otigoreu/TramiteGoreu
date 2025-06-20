using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Entities.Pide;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface ICredencialReniecRepository : IRepositoryBase<CredencialReniec>
    {
        Task<ICollection<CredencialReniecInfo>> GetAsync(string? descripcion);
        Task<CredencialReniecInfo> GetByNumdocAsync(string nuDniUsuario);
        Task FinalizedAsync(int id);
        Task InitializedAsync(int id);
    }
}
