using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Request
{
    public class UnidadOrganicaRequestDto
    {
        public string Descripcion { get; set; } = default!;
        public int IdEntidad { get; set; }
        public int? IdUnidadOrganicaPadre { get; set; }
    }
}
