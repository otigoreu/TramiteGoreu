namespace Goreu.Tramite.Entities
{
    public class Entidad : EntityBase
    {
        public string Descripcion { get; set; } = default!;
        public string Ruc { get; set; } = default!;

        public ICollection<UnidadOrganica> UnidadOrganicas { get; set; } = new List<UnidadOrganica>();
        public ICollection<EntidadAplicacion> EntidadAplicaciones { get; set; } = new List<EntidadAplicacion>();
    }
}
