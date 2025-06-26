﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Response
{
    public class EntidadResponseDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public string Ruc { get; set; } = default!;
        public bool Estado { get; set; } = true;
    }
}
