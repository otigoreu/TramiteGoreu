using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace Goreu.Tramite.Services.profiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<PersonaInfo, PersonaResponseDto>();
            CreateMap<Persona, PersonaResponseDto>();
            CreateMap<PersonaRequestDto, Persona>()
                .ForMember(d => d.FechaNac, o => o.MapFrom(x => DateOnly.Parse($"{x.fechaNac}")));
            CreateMap<Persona, PersonaInfo>();
        }
    }
}
