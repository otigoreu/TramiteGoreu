﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Dto.Response
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpirationDate{ get; set; }
    }
}
