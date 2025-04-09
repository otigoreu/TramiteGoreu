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
            CreateMap<Menu, MenuRequestDtoSingle>();
            CreateMap<MenuRequestDto, Menu>();
            CreateMap<MenuRequestDtoSingle, Menu>();

            CreateMap<Menu, MenuResponseDto>();


        }
    }
}
