using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Entities
{
    public class IndiceTabla : EntityBase
    {
        public string Descripcion { get; set; }

        public ICollection<Historial> Historials { get; set; } = new List<Historial>();
    }
}
