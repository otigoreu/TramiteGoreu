﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TramiteGoreu.Entities
{
    public class MenuRol
    {
        public int IdMenu { get; set; }
        public string IdRol { get; set; }
        public Menu Menu { get; set; }
        public Rol Rol { get; set; }
    }
}