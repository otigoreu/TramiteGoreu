﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Tramite.Dto.Response.Pide.Credenciales
{
    public class CredencialReniecResponseDto
    {
        public int Id { get; set; }
        public string nuDniConsulta { get; set; }
        public string nuDniUsuario { get; set; }
        public string nuRucUsuario { get; set; }
        public string password { get; set; }

        public DateTime fechaRegistro { get; set; }
        public Guid UsuarioID { get; set; }

        public int PersonaID { get; set; }
    }
}
