using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Repositories.Implementacion;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Services.Iplementation
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository repository;
        private readonly ILogger<MenuService> logger;
        private readonly IMapper mapper;
        private readonly UserManager<Usuario> usuario;
        private readonly RoleManager<IdentityRole> roleManager;

        public MenuService(IMenuRepository repository,
            ILogger<MenuService> logger,
            IMapper mapper,
            UserManager<Usuario> usuario,
            RoleManager<IdentityRole> roleManager)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.usuario = usuario;
            this.roleManager = roleManager;
        }
        public async Task<BaseResponseGeneric<int>> AddAsync(MenuRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                var roles = new List<MenuRol>();

                var menuDb = new Menu
                {
                    DisplayName = request.DisplayName,
                    IconName=request.IconName,
                    Route=request.Route,
                    IdAplicacion = request.IdAplicacion,
                    ParentMenuId = request.ParentMenuId == 0 ? null : request.ParentMenuId
                };
                response.Data = await repository.AddAsync(menuDb);

                foreach (var item in request.IdRoles)
                {
                    roles.Add(new MenuRol { IdMenu = menuDb.Id, IdRol = item });
                }
                menuDb.MenuRoles = roles;
                await repository.UpdateAsync();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al añadir la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<ICollection<MenuResponseDto>>> GetByAplicationAsync(int idAplication, string email)
        {
            var response = new BaseResponseGeneric<ICollection<MenuResponseDto>>();
            try
            {
                var persona = await usuario.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
                IList<string> roles = new List<string>();
                if (persona is not null)
                {
                    roles = await usuario.GetRolesAsync(persona);
                }
                else
                {
                    response.ErrorMessage = "No existe el usuario.";
                    return response;
                }
                //var menusDb = await repository.GetByIdAplicationAsync(idAplication);
                var roleIds = new List<string>();
                foreach (var role in roles)
                {
                    var roleEntity = await roleManager.FindByNameAsync(role);
                    if (roleEntity != null)
                    {
                        roleIds.Add(roleEntity.Id);
                    }
                }

                // Filtrar menús que coincidan con la aplicación y roles del usuario
                var menusDb = await repository.GetMenusByApplicationAndRolesAsync(idAplication, roleIds);

                if (menusDb.Count > 0)
                {
                    response.Data = mapper.Map<ICollection<MenuResponseDto>>(menusDb);
                    response.Success = true;
                }
                else
                {
                    response.ErrorMessage = $"No hay menús asignados a la aplicación con id {idAplication}.";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al añadir la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}
