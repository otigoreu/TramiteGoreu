using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TramiteGoreu.Entities
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
