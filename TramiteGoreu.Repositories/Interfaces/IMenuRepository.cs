using Goreu.Tramite.Entities.info;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IMenuRepository : IRepositoryBase<Menu>
    {
        Task<ICollection<Menu>> GetByIdAplicationAsync(int idAplication);
        Task<List<Menu>> GetMenusByApplicationAndRolesAsync(int applicationId, List<string> roleIds);
        Task<ICollection<MenuInfo>> GetAsync(string? displayName);
        Task<ICollection<MenuInfoRol>> GetAsyncWithRole(string? displayName);
        Task FinalizedAsync(string id);
        Task InitializedAsync(string id);
    }
}
