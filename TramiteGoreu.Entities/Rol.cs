using Goreu.Tramite.Entities;
using Microsoft.AspNetCore.Identity;

namespace TramiteGoreu.Entities
{
    public class Rol : IdentityRole
    {
        public bool Estado { get; set; } = true;

        public Guid IdEntidadAplicacion { get; set; }
        public EntidadAplicacion EntidadAplicacion { get; set; }
        
        public ICollection<MenuRol> MenuRoles { get; set; }
    }
}
