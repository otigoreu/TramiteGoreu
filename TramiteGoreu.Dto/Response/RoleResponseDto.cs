using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Response
{
    public class RoleResponseDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string NormalizedName { get; set; } = default!;
    }
}
