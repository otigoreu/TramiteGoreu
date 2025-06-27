namespace Goreu.Tramite.Services.profiles
{
    public class HistorialProfile : Profile
    {
        public HistorialProfile()
        {
            CreateMap<Historial, HistorialResponseDto>();
            CreateMap<HistorialRequestDto, Historial>();
        }
    }
}
