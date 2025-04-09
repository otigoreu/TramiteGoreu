using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Request
{
    public class MenuRequestDtoSingle
    {
        public string DisplayName { get; set; } = default!;
        public string IconName { get; set; } = default!;
        public string Route { get; set; } = default!;
        public int IdAplicacion { get; set; }
        public int? ParentMenuId { get; set; }
    }
}
