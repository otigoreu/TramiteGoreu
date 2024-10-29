using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TramiteGoreu.Entities
{
    public class Usuario : IdentityUser
    {
        [StringLength(100)]
        public string FirstName { get; set; } = default!;
        [StringLength(100)]
        public string LastName { get; set; } = default!;
        public ICollection<UsuarioAplicacion> UsuarioAplicaciones { get; set; }
        public int IdSede { get; set; }
        public int IdPersona { get; set; }
        public Sede Sede { get; set; }
        public Persona Persona {get; set;}
    }
}
