using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TramiteGoreu.Entities
{
    public class UsuarioAplicacion
    {
        public string IdUsuario { get; set; }
        public int IdAplicacion { get; set; }
        public Usuario Usuario{ get; set; }
        public Aplicacion Aplicacion { get; set; }
    }
}
