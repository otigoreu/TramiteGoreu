using TramiteGoreu.Entities;

namespace TramiteGoreu.Repositories.Implementacion
{
    public interface IMenuRepository : IRepositoryBase<Menu>
    {
        Task<ICollection<Menu>> GetByIdAplicationAsync(int idAplication);
        Task<List<Menu>> GetMenusByApplicationAndRolesAsync(int applicationId, List<string> roleIds);
    }
}
