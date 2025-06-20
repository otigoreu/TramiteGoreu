﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Entities.Pide
{
    public class CredencialReniec : EntityBase
    {
        public string nuDniUsuario { get; set; }
        public string nuRucUsuario { get; set; }
        public string password { get; set; }

        public DateTime fechaRegistro { get; set; }
        public Guid UsuarioID { get; set; }

        public int PersonaID { get; set; }
        public Persona Persona { get; set; }
    }
}
