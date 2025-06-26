using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.profiles
{
    public class UnidadOrganicaProfile : Profile
    {
        public UnidadOrganicaProfile()
        {
            CreateMap<UnidadOrganica, UnidadOrganicaResponseDto>()
            .ForMember(dest => dest.NombreEntidad,
                       opt => opt.MapFrom(src => src.Entidad != null ? src.Entidad.Descripcion : string.Empty))
            .ForMember(dest => dest.NombreDependencia,
                       opt => opt.MapFrom(src => src.Dependencia != null ? src.Dependencia.Descripcion : ""))
            .ForMember(dest => dest.CantidadHijos,
                       opt => opt.MapFrom(src => src.Hijos != null ? src.Hijos.Count : 0));

            CreateMap<UnidadOrganicaRequestDto, UnidadOrganica>()
                .ForMember(dest => dest.IdDependencia,
                       opt => opt.MapFrom(src => src.IdUnidadOrganicaPadre));
        }
    }
}
