using Goreu.Tramite.Entities;

namespace TramiteGoreu.Entities
{
    public class Aplicacion: EntityBase
    {
        public string Descripcion { get; set; } = default!;
        public ICollection<Menu> Menus { get; set; } = default!;
        public ICollection<EntidadAplicacion> EntidadAplicaciones { get; set; } = default!;

    }
}
