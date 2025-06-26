namespace Goreu.Tramite.Services.profiles
{
    public class AplicacionProfile : Profile
    {
        public AplicacionProfile()
        {
            CreateMap<Aplicacion, AplicacionResponseDto>();
            CreateMap<AplicacionRequestDtoSingle, Aplicacion>();
            CreateMap<AplicacionRequestDto, Aplicacion>();
        }
    }
}
