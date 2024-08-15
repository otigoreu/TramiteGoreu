using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Dto.Request
{
    public class ChangePasswordRequestDto
    {
        public string OldPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
    }
}
