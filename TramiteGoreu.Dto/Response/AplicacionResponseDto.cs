namespace Goreu.Tramite.Dto.Response
{
    public class AplicacionResponseDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public bool Estado { get; set; }
    }
}
