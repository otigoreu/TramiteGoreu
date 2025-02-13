using Goreu.Tramite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Repositories.Interfaces
{
    public interface ITipoDocumentoRepository: IRepositoryBase<TipoDocumento>
    {
        Task FinalizedAsync(int id);
        Task InitializedAsync(int id);
    }
}
