using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Entities;
using Goreu.Tramite.Entities.info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities.info;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface ITipoDocumentoRepository: IRepositoryBase<TipoDocumento>
    {
        Task<ICollection<TipoDocumentoInfo>> GetAsync(string? descripcion);
        Task FinalizedAsync(int id);
        Task InitializedAsync(int id);
    }
}
