using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Entities.info
{
    public class SedeInfo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public bool status { get; set; } = default!;
    }
}
