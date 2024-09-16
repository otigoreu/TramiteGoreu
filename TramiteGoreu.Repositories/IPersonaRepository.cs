using TramiteGoreu.Dto.Request;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace TramiteGoreu.Repositories
{
    public interface IPersonaRepository : IRepositoryBase<Persona>
    {
        Task<ICollection<PersonaInfo>> GetAsync(string? nombres, PaginationDto pagination);
        Task<ICollection<PersonaInfo>> GetAsyncEmail(string? email, PaginationDto pagination);
        Task FinalizedAsync (int id);
    }
}