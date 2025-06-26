namespace Goreu.Tramite.Services.profiles
{
    public class EntidadProfile : Profile
    {
        public EntidadProfile()
        {
            CreateMap<Entidad, EntidadResponseDto>();
            CreateMap<EntidadRequestDto, Entidad>();
        }
    }
}
