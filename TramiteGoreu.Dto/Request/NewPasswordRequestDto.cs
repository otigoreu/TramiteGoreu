using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Request
{
    public class NewPasswordRequestDto
    {
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; } = default!;

    }
}
