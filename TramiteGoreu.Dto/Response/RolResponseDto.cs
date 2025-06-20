using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Response
{
    public class RolResponseDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool CanCreate { get; set; } = true;
        public bool CanDelete { get; set; } = true;

        public bool CanSearch { get; set; } = true;
        public bool CanUpdate { get; set; } = true;
        public string NormalizedName { get; set; } = default!;
        public bool Status { get; set; } = default!;

    }
}
