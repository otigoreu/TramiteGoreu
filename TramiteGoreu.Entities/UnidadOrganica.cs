using Goreu.Tramite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Entities
{
    public class UnidadOrganica :EntityBase
    {
        public string Descripcion { get; set; } = default!;
        public Guid IdEntidad{ get; set; }
        public Entidad Entidad{ get; set; }
        public ICollection<UsuarioUnidadOrganica> UsuarioUnidadOrganicas { get; set; }

    }
}
