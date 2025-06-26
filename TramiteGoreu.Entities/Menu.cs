using Goreu.Tramite.Entities;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Entities
{
    public class Menu : EntityBase
    {
        public string Descripcion{ get; set; } = default!;
        public string Icono { get; set; } = default!;
        public string Ruta { get; set; } = default!;
        
        public int IdAplicacion { get; set; }
        public Aplicacion Aplicacion { get; set; }

        public ICollection<MenuRol> MenuRoles { get; set; }

        //auto referencia
        public int? IdMenu { get; set; }
        public Menu ParentMenu { get; set; }

        // Colección de menús hijos
        public ICollection<Menu> MenuHijos { get; set; }
    }
}
