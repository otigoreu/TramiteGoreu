using Goreu.Tramite.Entities;
using System.ComponentModel.DataAnnotations;

namespace TramiteGoreu.Entities
{
    public class Persona : EntityBase
    {
        public string Nombres { get; set; } = default!;
        public string ApellidoPat { get; set; } = default!;
        public string ApellidoMat { get; set; } = default!;
        public DateTime FechaNac { get; set; }
        public string Edad { get; set; } = default!;
        public string Email { get; set; } = default!;
        public int IdTipoDoc { get; set; }
        public  string NroDoc { get; set; } = default!;
        public TipoDocumento TipoDocumento { get; set; }
        
        // Relación uno a muchos
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
