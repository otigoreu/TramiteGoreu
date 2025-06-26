namespace Goreu.Tramite.Services.profiles
{
    public class EntidadAplicacionProfile : Profile
    {
        public EntidadAplicacionProfile()
        {
            CreateMap<EntidadAplicacion, EntidadAplicacionResponseDto>();
            CreateMap<EntidadAplicacionRequestDto, EntidadAplicacion>();
        }
    }
}
