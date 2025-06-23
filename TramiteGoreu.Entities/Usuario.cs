using Goreu.Tramite.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TramiteGoreu.Entities
{
    public class Usuario : IdentityUser
    {
        
        public int IdPersona { get; set; }
        public Persona Persona {get; set;}
        public ICollection<UsuarioUnidadOrganica> UsuarioUnidadOrganicas { get; set; }
    }
}
