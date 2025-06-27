using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Request
{
    public class HistorialRequestDto
    {
        public DateTime FechaRegistro { get; set; }
        public string operacion { get; set; }
        public int ID_pk { get; set; }

        public int idIndiceTabla { get; set; }
        public string idUsuario { get; set; }
    }
}
