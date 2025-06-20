using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Entities
{
    public class UsuarioUnidadOrganica :EntityBase
    {
        public string IdUsuario { get; set; }
        public Guid IdUnidadOrganica { get; set; }
        public Usuario Usuario{ get; set; }
        public UnidadOrganica UnidadOrganica { get; set; }
    }
}
