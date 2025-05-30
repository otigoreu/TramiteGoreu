using AutoMapper;
using Azure;
using Goreu.Tramite.Dto.Request;
using Goreu.Tramite.Dto.Response;
using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Implementacion;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Services.Iplementation
{
    public class RolService:IRolService
    {
        private readonly RoleManager<IdentityRole> rolManager;
        private readonly ILogger<RolService> logger;
        private readonly IConfiguration configuration;
        private readonly SignInManager<Role> singInManager;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly IRolRepository repository;

        public RolService(
            RoleManager<IdentityRole> rolManager,
            ILogger<RolService> logger,
            IConfiguration configuration,
            IMapper mapper,
            ApplicationDbContext context ,
            IRolRepository repository
            ) {

            this.rolManager = rolManager;
            this.logger = logger;
            this.configuration = configuration;
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
        }
        //FUNCIONA
        public async Task<BaseResponseGeneric<string>> AddSync(RolRequestDto request)
        {
            var response = new BaseResponseGeneric<string>();
            try
            {
                if (await rolManager.RoleExistsAsync(request.Name))
                {
                    response.ErrorMessage = "Rol ya existe";
                    return response;
                }
                response.Data = await repository.AddAsync(mapper.Map<Role>(request));
                response.Success = true;

                return response;

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error al registrar el rol";
                logger.LogError(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(string id)
        {
            var response = new BaseResponse();
            try
            {

                if (await rolManager.FindByIdAsync(id) == null)
                {
                    
                    
                    response.ErrorMessage = "Rol no existe";
                }
                else {

                    await rolManager.DeleteAsync(new IdentityRole(id));
                    response.Success = true;

                }

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error al Eliminar los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<ICollection<RolResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<RolResponseDto>>();
            try
            {
                var data = await repository.GetAllAsync();
                response.Data = mapper.Map<ICollection<RolResponseDto>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        //FUNCIONA
        public async Task<BaseResponseGeneric<RolResponseDto>> GetAsync(string id)
        {
            var response = new BaseResponseGeneric<RolResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<RolResponseDto>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        //FUNCIONA
        public async Task<BaseResponse> UpdateAsync(string id, RolRequestDto request)
        {
            var response = new BaseResponse();

            try
            {
                var data = await rolManager.FindByIdAsync(id);
                if (data is null) {
                    response.ErrorMessage = $"El Rol con id {id} no fue encontrado";
                }
                await rolManager.UpdateAsync(mapper.Map(request,data));
                response.Success = true;

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "";
                logger.LogError(ex,"{ErrorMessage} {Message}",response.ErrorMessage,ex.Message);
            }
            return response;
        }
    }
}
