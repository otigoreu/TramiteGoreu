using Goreu.Tramite.Entities.info;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TramiteGoreu.Entities;
//using TramiteGoreu.Persistence.Migrations;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IRolRepository 
    {
        Task<ICollection<Rol>> GetAllAsync();
        Task<Rol?> GetAsync(string id);
        Task<string> AddAsync(Rol rol);
        Task DeleteAsync(string id);
        Task FinalizedAsync(string id);
        Task InitializedAsync(string id);


    }
}
