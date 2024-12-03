using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.profiles
{
    public class SedeProfile : Profile
    {
        public SedeProfile()
        {
            CreateMap<Sede, SedeResponseDto>();
            CreateMap<SedeRequestDto, Sede>();
        }
    }
}
