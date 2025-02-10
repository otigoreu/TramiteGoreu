using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Entities.info
{
    public class PersonaInfo
    {
        public int Id { get; set; }
        public string nombres { get; set; } = default!;
        public string apellidos { get; set; } = default!;
        public DateTime fechaNac { get; set; } = default!;
        public string direccion { get; set; } = default!;
        public string referencia { get; set; } = default!;
        public string celular { get; set; } = default!;
        public string edad { get; set; } = default!;
        public string email { get; set; } = default!;
        public string tipoDoc { get; set; } = default!;
        public string nroDoc { get; set; } = default!;
        public bool status { get; set; } = default!;
    }
}
