﻿using AutoMapper;
using Azure;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Services.Interface;
using Microsoft.Extensions.Logging;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.Iplementation
{
    //public class SedeService : ISedeService
    //{
    //    private readonly ISedeRepository repository;
    //    private readonly ILogger<SedeService> logger;
    //    private readonly IMapper mapper;

    //    public SedeService(ISedeRepository repository, ILogger<SedeService> logger, IMapper mapper)
    //    {
    //        this.repository = repository;
    //        this.logger = logger;
    //        this.mapper = mapper;
    //    }
    //    public async Task<BaseResponseGeneric<int>> AddAsync(SedeRequestDto request)
    //    {
    //        var response = new BaseResponseGeneric<int>();
    //        try
    //        {
    //            response.Data = await repository.AddAsync(mapper.Map<UnidadOrganica>(request));
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al obtener los datos";
    //            logger.LogError(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);

    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponse> DeleteAsync(int id)
    //    {
    //        var response = new BaseResponse();
    //        try
    //        {
    //            await repository.DeleteAsync(id);
    //            response.Success = true;

    //        }
    //        catch (Exception ex)
    //        {

    //            response.ErrorMessage = "Ocurrio un error al deshabilitar los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponse> FinalizedAsync(int id)
    //    {
    //        var response = new BaseResponse();
    //        try
    //        {
    //            await repository.FinalizedAsync(id);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al finalizar Datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponseGeneric<ICollection<SedeResponseDto>>> GetAsync()
    //    {
    //        var response = new BaseResponseGeneric<ICollection<SedeResponseDto>>();
    //        try
    //        {
    //            var data = await repository.GetAsync();
    //            response.Data = mapper.Map<ICollection<SedeResponseDto>>(data);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al obtener los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponseGeneric<SedeResponseDto>> GetAsync(int id)
    //    {
    //        var response = new BaseResponseGeneric<SedeResponseDto>();
    //        try
    //        {
    //            var data = await repository.GetAsync(id);
    //            response.Data = mapper.Map<SedeResponseDto>(data);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al obtener los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponseGeneric<ICollection<SedeInfo>>> GetAsync(string? descripcion)
    //    {
    //        var response = new BaseResponseGeneric<ICollection<SedeInfo>>();
    //        try
    //        {

    //            response.Data = await repository.GetAsync(descripcion);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al obtener los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponse> InitializedAsync(int id)
    //    {
    //        var response = new BaseResponse();
    //        try
    //        {
    //            await repository.InitializedAsync(id);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al Inicializar Datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponse> UpdateAsync(int id, SedeRequestDto request)
    //    {
    //        var response = new BaseResponse();
    //        try
    //        {
    //            var data = await repository.GetAsync(id);
    //            if (data is null)
    //            {
    //                response.ErrorMessage = $"la persona con id {id} no fue encontrado";
    //            }

    //            mapper.Map(request, data);
    //            await repository.UpdateAsync();
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al actualizar  los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }
    //}
}
