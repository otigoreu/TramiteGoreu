using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Entities
{
    [Table("UsuarioUnidadOrganica")]
    public class UsuarioUnidadOrganica : EntityBase
    {
        [StringLength(450)]
        public string IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("UsuarioUnidadOrganicas")]
        public Usuario Usuario { get; set; }

        public int IdUnidadOrganica { get; set; }

        [ForeignKey("IdUnidadOrganica")]
        [InverseProperty("UsuarioUnidadOrganicas")]
        public UnidadOrganica UnidadOrganica { get; set; }
    }
}
