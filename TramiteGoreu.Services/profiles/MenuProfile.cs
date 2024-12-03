using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuRequestDto>();
            CreateMap<Menu, MenuResponseDto>();


        }
    }
}
