using AutoMapper;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.Iplementation
{
    public class AplicacionService : IAplicacionService
    {
        private readonly IAplicacionRepository repository;
        private readonly ILogger<AplicacionService> logger;
        private readonly IMapper mapper;

        public AplicacionService(IAplicacionRepository repository, ILogger<AplicacionService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<BaseResponseGeneric<int>> AddAsync(AplicacionRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Aplicacion>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al guardar los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.Success = true;

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error al deshabilitar los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<ICollection<AplicacionResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<AplicacionResponseDto>>();
            try
            {
                var data = await repository.GetAsync();
                response.Data = mapper.Map<ICollection<AplicacionResponseDto>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<AplicacionResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<AplicacionResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<AplicacionResponseDto>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, AplicacionRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = $"la persona con id {id} no fue encontrado";
                }

                mapper.Map(request, data);
                await repository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al actualizar  los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}
