using System.ComponentModel.DataAnnotations.Schema;

namespace Goreu.Tramite.Entities
{
    [Table("EntidadAplicacion")]
    public class EntidadAplicacion : EntityBase
    {
        public int IdEntidad { get; set; }
        public int IdAplicacion { get; set; }

        [ForeignKey("IdEntidad")]
        [InverseProperty("EntidadAplicaciones")]
        public Entidad Entidad  {get; set; }

        [ForeignKey("IdAplicacion")]
        [InverseProperty("EntidadAplicaciones")]
        public Aplicacion Aplicacion { get; set; }

        public ICollection<Rol> Roles { get; set; } = default!;
    }
}
