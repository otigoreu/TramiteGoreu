using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Entities
{
    public class Sede :EntityBase
    {
        public string Descripcion { get; set; } = default!;
        public ICollection<Usuario> Users { get; set; } = default!;
        public ICollection<SedeAplicacion> SedeAplications { get; set; }
    }
}
