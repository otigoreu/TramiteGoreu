using Goreu.Tramite.Entities.info;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence.Migrations;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface IRolRepository 
    {
        Task<ICollection<Rol>> GetAsync();
        Task<Rol?> GetAsync(string id);
        Task<string> AddAsync(Rol rol);


    }
}
