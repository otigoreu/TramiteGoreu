using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Response
{
    public class EntidadAplicacionResponseDto
    {
        public int Id { get; set; }
        public int IdEntidad { get; set; }
        public int IdAplicacion { get; set; }
        public string DescripcionAplicacion { get; set; }
        public Boolean Estado { get; set; }
    }
}
