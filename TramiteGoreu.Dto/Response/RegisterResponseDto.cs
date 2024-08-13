using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Dto.Response
{
    public class RegisterResponseDto: LoginResponseDto
    {
        public string UserId { get; set; } = default!;
    }
}
