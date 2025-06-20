using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Entities.Pide;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class CredencialReniecRepository : RepositoryBase<CredencialReniec>, ICredencialReniecRepository
    {
        private readonly IHttpContextAccessor httpContext;

        public CredencialReniecRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }

        public async Task<CredencialReniecInfo> GetByNumdocAsync(string nuDniUsuario)
        {
            var credencialReniec = await context.Set<CredencialReniec>()
                .Where(x => x.Persona.NroDoc == nuDniUsuario)
                .AsNoTracking()
                .Select(x => new CredencialReniecInfo
                {
                    nuRucUsuario = x.nuRucUsuario,
                    password = x.password
                }).FirstOrDefaultAsync();

            if (credencialReniec == null) return null;

            return credencialReniec;
        }

        Task ICredencialReniecRepository.FinalizedAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<CredencialReniecInfo>> ICredencialReniecRepository.GetAsync(string? descripcion)
        {
            throw new NotImplementedException();
        }

        Task ICredencialReniecRepository.InitializedAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
