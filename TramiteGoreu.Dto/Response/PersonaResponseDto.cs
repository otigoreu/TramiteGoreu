using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Dto.Response
{
    public class PersonaResponseDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public DateOnly FechaNac { get; set; }
        public string Direccion { get; set; } = default!;
        public string Referencia { get; set; } = default!;
        public string Celular { get; set; } = default!;
        public string Edad { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string TipoDoc { get; set; } = default!;
        public string NroDoc { get; set; } = default!;
        
    }
}
