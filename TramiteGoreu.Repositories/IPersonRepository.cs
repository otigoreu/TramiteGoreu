using TramiteGoreu.Dto.Request;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace TramiteGoreu.Repositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<ICollection<PersonInfo>> GetAsync(string? nombres, PaginationDto pagination);
        Task FinalizedAsync (int id);
    }
}