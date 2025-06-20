using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.profiles
{
    public class RolProfile:Profile
    {

        public RolProfile()
        {
            CreateMap<RolRequestDto, Rol>();
            CreateMap<Rol, RolResponseDto>();
        
        }
    }
}
