using Goreu.Tramite.Entities;
using Microsoft.AspNetCore.Identity;

namespace Goreu.Tramite.Entities
{
    public class Rol : IdentityRole
    {
        public bool Estado { get; set; } = true;

        public int IdEntidadAplicacion { get; set; }
        public EntidadAplicacion EntidadAplicacion { get; set; }
        
        public ICollection<MenuRol> MenuRoles { get; set; }
    }
}
