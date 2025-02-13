using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Entities
{
    public class TipoDocumento : EntityBase
    {
        public string Descripcion { get; set; } = default!;
        public string Abrev { get; set; } = default!;
    }
}
