using AutoMapper;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace TramiteGoreu.Services.profiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<PersonaInfo, PersonaResponseDto>();
            CreateMap<Persona, PersonaResponseDto>();
            CreateMap<PersonaRequestDto, Persona>()
                .ForMember(d => d.fechaNac, o => o.MapFrom(x => DateOnly.Parse($"{x.fechaNac}")));
        }
    }
}
