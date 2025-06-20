using AutoMapper;
using Goreu.Tramite.Dto.Request.Pide.Credenciales;
using Goreu.Tramite.Dto.Response.Pide.Credenciales;
using Goreu.Tramite.Entities.Pide;

namespace Goreu.Tramite.Services.profiles
{
    public class CredencialReniecProfile : Profile
    {
        public CredencialReniecProfile()
        {
            CreateMap<CredencialReniec, CredencialReniecResponseDto>();
            CreateMap<AddCredencialReniecRequestDto, CredencialReniec>();
        }
    }
}
