namespace Goreu.Tramite.Entities
{
    public class MenuRol : EntityBase
    {
        public bool Operacion { get; set; } = true;
        public bool Consulta { get; set; } = true;

        public int IdMenu { get; set; }
        public Menu Menu { get; set; }

        public string IdRole { get; set; }
        public Rol Rol { get; set; }
    }
}
