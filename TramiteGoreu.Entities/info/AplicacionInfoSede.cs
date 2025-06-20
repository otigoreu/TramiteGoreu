using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Entities.info
{
    public class AplicacionInfoSede
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public int IdSede { get; set; }
        public string Sede { get; set; } = default!;
        public bool status { get; set; } = default!;

    }
}
