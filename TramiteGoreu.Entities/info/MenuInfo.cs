using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Entities.info
{
    public class MenuInfo
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = default!;
        public string IconName { get; set; } = default!;
        public string Route { get; set; } = default!;
        public int IdAplicacion { get; set; }
        public string Aplicacion { get; set; } = default!;
        public int? ParentMenuId { get; set; }
        public bool status { get; set; } = default!;
    }
}
