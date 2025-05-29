using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario?> GetAsync(string id);
    }
}
