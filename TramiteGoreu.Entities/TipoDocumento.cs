namespace Goreu.Tramite.Entities
{
    public class TipoDocumento : EntityBase
    {
        public string Descripcion { get; set; } = default!;
        public string Abrev { get; set; } = default!;

        public ICollection<Persona> Personas { get; private set; }
    }
}
