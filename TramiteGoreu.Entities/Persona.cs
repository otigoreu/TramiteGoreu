﻿using System.ComponentModel.DataAnnotations;

namespace TramiteGoreu.Entities
{
    public class Persona : EntityBase
    {
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public DateOnly FechaNac { get; set; }
        public string Direccion { get; set; } = default!;
        public string Referencia { get; set; } = default!;
        public string Celular { get; set; } = default!;
        public string Edad { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string TipoDoc { get; set; } = default!;
        public  string NroDoc { get; set; } = default!;
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
