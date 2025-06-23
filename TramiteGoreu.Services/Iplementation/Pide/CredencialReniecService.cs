using AutoMapper;
using Azure;
using Azure.Core;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Request.Pide.Credenciales;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Dto.Response.Pide.Credenciales;
using Goreu.Tramite.Entities.info;
using Goreu.Tramite.Entities.Pide;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Services.Interface;
using Microsoft.Extensions.Logging;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.Iplementation
{
    //public class CredencialReniecService : ICredencialReniecService
    //{
    //    private readonly ICredencialReniecRepository _credencialReniecRepository;
    //    private readonly ILogger<CredencialReniecService> logger;
    //    private readonly IMapper _credencialReniecMapper;

    //    public CredencialReniecService(ICredencialReniecRepository _credencialReniecRepository, ILogger<CredencialReniecService> logger, IMapper _credencialReniecMapper)
    //    {
    //        this._credencialReniecRepository = _credencialReniecRepository;
    //        this.logger = logger;
    //        this._credencialReniecMapper = _credencialReniecMapper;
    //    }
    //    public async Task<BaseResponseGeneric<int>> AddAsync(AddCredencialReniecRequestDto request)
    //    {
    //        var response = new BaseResponseGeneric<int>();
    //        try
    //        {
    //            response.Data = await _credencialReniecRepository.AddAsync(_credencialReniecMapper.Map<CredencialReniec>(request));
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
    //            await _credencialReniecRepository.DeleteAsync(id);
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
    //            await _credencialReniecRepository.FinalizedAsync(id);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al finalizar Datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponseGeneric<ICollection<CredencialReniecResponseDto>>> GetAsync()
    //    {
    //        var response = new BaseResponseGeneric<ICollection<CredencialReniecResponseDto>>();
    //        try
    //        {
    //            var data = await _credencialReniecRepository.GetAsync();
    //            response.Data = _credencialReniecMapper.Map<ICollection<CredencialReniecResponseDto>>(data);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al obtener los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponseGeneric<CredencialReniecResponseDto>> GetAsync(int id)
    //    {
    //        var response = new BaseResponseGeneric<CredencialReniecResponseDto>();
    //        try
    //        {
    //            var data = await _credencialReniecRepository.GetAsync(id);
    //            response.Data = _credencialReniecMapper.Map<CredencialReniecResponseDto>(data);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al obtener los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponseGeneric<ICollection<CredencialReniecInfo>>> GetAsync(string? descripcion)
    //    {
    //        var response = new BaseResponseGeneric<ICollection<CredencialReniecInfo>>();
    //        try
    //        {

    //            response.Data = await _credencialReniecRepository.GetAsync(descripcion);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al obtener los datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponseGeneric<CredencialReniecInfo>> GetByNumdocAsync(string nuDniUsuario)
    //    {
    //        var response = new BaseResponseGeneric<CredencialReniecInfo>();

    //        try
    //        {
    //            var data = await _credencialReniecRepository.GetByNumdocAsync(nuDniUsuario);

    //            if (data is null)
    //            {
    //                response.ErrorMessage = "No se encontraron credenciales para el número de documento proporcionado.";
    //                return response;
    //            }

    //            response.Data = data;
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            const string errorMsg = "Ocurrió un error al obtener las credenciales de RENIEC.";
    //            response.ErrorMessage = errorMsg;
    //            logger.LogError(ex, "{Error}: {Exception}", errorMsg, ex.Message);
    //        }

    //        return response;
    //    }

    //    public async Task<BaseResponse> InitializedAsync(int id)
    //    {
    //        var response = new BaseResponse();
    //        try
    //        {
    //            await _credencialReniecRepository.InitializedAsync(id);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            response.ErrorMessage = "Ocurrio un error al Inicializar Datos";
    //            logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
    //        }
    //        return response;
    //    }

    //    public async Task<BaseResponse> UpdateAsync(int id, AddCredencialReniecRequestDto request)
    //    {
    //        var response = new BaseResponse();
    //        try
    //        {
    //            var data = await _credencialReniecRepository.GetAsync(id);
    //            if (data is null)
    //            {
    //                response.ErrorMessage = $"la persona con id {id} no fue encontrado";
    //            }

    //            _credencialReniecMapper.Map(request, data);
    //            await _credencialReniecRepository.UpdateAsync();
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
