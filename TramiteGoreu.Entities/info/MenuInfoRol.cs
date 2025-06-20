namespace Goreu.Tramite.Entities.info
{
    public class MenuInfoRol
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = default!;
        public string IconName { get; set; } = default!;
        public string Route { get; set; } = default!;
        
        public int IdAplicacion { get; set; }
        public string Aplicacion { get; set; } = default!;
        public string IdRol { get; set; }
        public string Rol { get; set; } = default!;
        
        public bool status { get; set; } = default!;
        public int? ParentMenuId { get; set; }
    }
}
