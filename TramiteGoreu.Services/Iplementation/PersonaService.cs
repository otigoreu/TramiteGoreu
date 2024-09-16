﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;
using TramiteGoreu.Repositories;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Services.Iplementation
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository repository;
        private readonly ILogger<PersonaService> logger;
        private readonly IMapper mapper;

        public PersonaService(IPersonaRepository repository, ILogger<PersonaService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<BaseResponseGeneric<ICollection<PersonaInfo>>> GetAsync(string? nombres, PaginationDto pagination)
        {
            var response= new BaseResponseGeneric<ICollection<PersonaInfo>>();
            try
            {
                
                response.Data= await repository.GetAsync(nombres, pagination);
                response.Success=true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<PersonaResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<PersonaResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<PersonaResponseDto>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<int>> AddAsync(PersonaRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Persona>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al guardar los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> UpdateAsync(int id, PersonaRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var data = await repository.GetAsync(id);
                if (data is null) 
                {
                    response.ErrorMessage = $"la persona con id {id} no fue encontrado";
                }

                mapper.Map(request,data);
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

        public async Task<BaseResponse> DeleteAsync(int id)
        {
           var response =new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.Success = true;

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error al actualizar  los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> FinalizedAsync(int id)
        {
           var response= new BaseResponse();
            try
            {
                await repository.FinalizedAsync(id);
                response.Success= true;

            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al finalizar los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<PersonaInfo>> GetAsyncBYEmail(string email)
        {
            var response = new BaseResponseGeneric<PersonaInfo>();
            try
            {

                response.Data = mapper.Map<PersonaInfo> ( (await repository.GetAsync(predicate: s => s.email == email)).FirstOrDefault());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}