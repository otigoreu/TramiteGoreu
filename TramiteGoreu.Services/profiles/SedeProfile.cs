using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Services.profiles
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
