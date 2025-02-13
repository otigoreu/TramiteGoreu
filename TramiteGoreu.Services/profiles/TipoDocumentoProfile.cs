using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Entities;
using Goreu.Tramite.Entities.info;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace Goreu.Tramite.Services.profiles
{
    public class TipoDocumentoProfile : Profile
    {
        public TipoDocumentoProfile() {
            CreateMap<TipoDocumentoInfo, TipoDocumentoResponseDto>();
            CreateMap<TipoDocumento, TipoDocumentoResponseDto>();
            CreateMap<TipoDocumentoRequestDto, TipoDocumento>();
            CreateMap<TipoDocumento, TipoDocumentoInfo>();

        }
    }
}
