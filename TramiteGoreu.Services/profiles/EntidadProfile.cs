namespace Goreu.Tramite.Services.profiles
{
    public class EntidadProfile : Profile
    {
        public EntidadProfile()
        {
            CreateMap<Entidad, EntidadResponseDto>()
                .ForMember(dest => dest.CantidadAplicaciones, opt => opt.MapFrom(src => src.EntidadAplicaciones.Count));

            CreateMap<EntidadRequestDto, Entidad>();
        }
    }
}
