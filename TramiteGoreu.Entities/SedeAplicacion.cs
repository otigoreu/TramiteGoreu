namespace TramiteGoreu.Entities
{
    public class SedeAplicacion
    {
        public int IdSede { get; set; }
        public int IdAplicacion { get; set; }
        public Aplicacion Aplicacion{ get; set; }
        public Sede Sede { get; set; }
    }
}
