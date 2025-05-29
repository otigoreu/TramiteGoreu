using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.profiles
{
    public class AplicacionProfile : Profile
    {
        public AplicacionProfile()
        {
            CreateMap<Aplicacion, AplicacionResponseDto>();
            CreateMap<AplicacionRequestDto, Aplicacion>();
        }
    }
}
