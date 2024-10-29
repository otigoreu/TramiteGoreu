using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Dto.Request
{
    public class MenuRequestDto
    {
        public string DisplayName { get; set; } = default!;
        public string IconName { get; set; } = default!;
        public string Route { get; set; } = default!;
        public int IdAplicacion { get; set; }
        public List<string> IdRoles { get; set; } = default!;
        public int? ParentMenuId { get; set; }
    }
}
