using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Entities
{
    public class MenuRol : EntityBase
    {
        public bool Operacion { get; set; } = true;
        public bool Consulta { get; set; } = true;

        public Guid IdMenu { get; set; }
        public Menu Menu { get; set; }

        public string IdRole { get; set; }
        public Rol Rol { get; set; }

        

    }
}
