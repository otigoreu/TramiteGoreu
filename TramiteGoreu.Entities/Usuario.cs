using Microsoft.AspNetCore.Identity;

namespace Goreu.Tramite.Entities
{
    public class Usuario : IdentityUser
    {
        public int IdPersona { get; set; }
        public Persona Persona {get; set;}

        public ICollection<UsuarioUnidadOrganica> UsuarioUnidadOrganicas { get; set; } = new List<UsuarioUnidadOrganica>();
    }
}
