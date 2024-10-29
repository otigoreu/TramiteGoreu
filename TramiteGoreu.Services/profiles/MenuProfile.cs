using AutoMapper;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Services.profiles
{
    public  class MenuProfile: Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuRequestDto>();
            
        }
    }
}
