namespace TramiteGoreu.Entities
{
    public class Aplicacion: EntityBase
    {
        public string Descripcion { get; set; } = default!;
        public ICollection<Menu> Menus { get; set; } = default!;
        public ICollection<SedeAplicacion> SedeAplicaciones { get; set; }
        public ICollection<UsuarioAplicacion> UsuarioAplicaciones { get; set; }

    }
}
