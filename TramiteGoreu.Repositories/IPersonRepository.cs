using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace TramiteGoreu.Repositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<ICollection<PersonInfo>> GetAsync(string? nombres);
        Task FinalizedAsync (int id);
    }
}