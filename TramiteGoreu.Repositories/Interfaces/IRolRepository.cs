using Goreu.Tramite.Entities.info;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence.Migrations;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IRolRepository 
    {
        Task<ICollection<Role>> GetAllAsync();
        Task<Role?> GetAsync(string id);
        Task<string> AddAsync(Role rol);
        Task DeleteAsync(string id);
        Task FinalizedAsync(string id);
        Task InitializedAsync(string id);


    }
}
