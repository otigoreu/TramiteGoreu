using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Entities.info
{
    public class UnidadOrganicaInfo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public string Entidad { get; set; } = default!;
        public string Dependencia { get; set; } = default!;
    }
}
