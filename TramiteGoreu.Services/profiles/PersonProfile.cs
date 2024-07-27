using AutoMapper;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace TramiteGoreu.Services.profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonInfo, PersonResponseDto>();
            CreateMap<Person, PersonResponseDto>();
            CreateMap<PersonRequestDto, Person>()
                .ForMember(d => d.fechaNac, o => o.MapFrom(x => Convert.ToDateTime($"{x.fechaNaci}")));
        }
    }
}
