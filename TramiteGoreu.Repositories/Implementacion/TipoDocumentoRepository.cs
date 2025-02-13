using Goreu.Tramite.Entities;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Repositories.Implementacion
{
    public class TipoDocumentoRepository : RepositoryBase<TipoDocumento>, ITipoDocumentoRepository
    {
        private readonly IHttpContextAccessor httpContext;

        public TipoDocumentoRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }

        public async Task FinalizedAsync(int id)
        {
            var tipoDocu= await GetAsync(id);
            if (tipoDocu is not  null)
            {
                tipoDocu.Status = false;
                await UpdateAsync();
            }
        }

        public async Task InitializedAsync(int id)
        {

            var tipoDocu = await context.Set<TipoDocumento>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
           
            if (tipoDocu is not null)
            {
                tipoDocu.Status = true;
                context.Set<TipoDocumento>().Update(tipoDocu);
                await context.SaveChangesAsync();

            }

        }
    }
}
