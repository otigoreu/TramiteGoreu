using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Entities
{
    public  class Historial : EntityBase
    {
        public DateTime FechaRegistro { get; set; }
        public string operacion { get; set; }
        public int ID_pk { get; set; }

        public int idIndiceTabla { get; set; }
        public IndiceTabla IndiceTabla { get; set; }

        public string idUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
