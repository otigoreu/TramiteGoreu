using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Entities
{
    public class EntidadAplicacion : EntityBase
    {
        public Guid IdEntidad { get; set; }
        public Guid IdAplicacion { get; set; }
        public Entidad Entidad  {get; set; }
        public Aplicacion Aplicacion { get; set; }
        public ICollection<Rol> Roles { get; set; } = default!;
    }
}
