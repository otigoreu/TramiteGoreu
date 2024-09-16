using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Persistence;
using TramiteGoreu.Repositories;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Services.Iplementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<UserService> logger;
        private readonly IOptions<AppSettings> options;
        private readonly IPersonaRepository personaRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(UserManager<ApplicationUser> userManager, ILogger<UserService> logger,
            IOptions<AppSettings> options, IPersonaRepository personaRepository,
            SignInManager<ApplicationUser> signInManager, IMapper mapper, IEmailService emailService,
            ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.options = options;
            this.personaRepository = personaRepository;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.emailService = emailService;
            this.context = context;
            this.roleManager = roleManager;
        }

        public async Task<BaseResponseGeneric<RegisterResponseDto>> RegisterAsync(RegisterRequestDto request)
        {
            var response = new BaseResponseGeneric<RegisterResponseDto>();
            try
            {
                var user = new ApplicationUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EmailConfirmed = true
                };
                var resultado = await userManager.CreateAsync(user, request.ConfirmPassword);
                if (resultado.Succeeded)
                {
                    user = await userManager.FindByEmailAsync(request.Email);

                    if (user is not null)
                    {
                        await userManager.AddToRoleAsync(user, Constants.RoleCustomer);

                        var persona = new PersonaRequestDto()
                        {
                            email = request.Email,
                            nombres = request.FirstName,
                            apellidos = request.LastName,
                            fechaNac="2024-01-01",
                            direccion = "",
                            referencia = "",
                            celular = "",
                            edad = "",
                            tipoDoc = "",
                            nroDoc = "",
                        };

                        await personaRepository.AddAsync(mapper.Map<Persona>(persona));

                        // TODO: Enviar un email

                        response.Success = true;

                        var tokenResponse = await ConstruirToken(user);//returning jwt
                        response.Data = new RegisterResponseDto
                        {
                            UserId = user.Id,
                            Token = tokenResponse.Token,
                            ExpirationDate = tokenResponse.ExpirationDate,
                            Roles=tokenResponse.Roles
                        };
                    }
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = String.Join(" ", resultado.Errors.Select(x => x.Description).ToArray());
                    logger.LogWarning(response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al registrar el usuario.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<LoginResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var response = new BaseResponseGeneric<LoginResponseDto>();
            try
            {
                var resultado = await signInManager.PasswordSignInAsync(request.UserName, request.Password, isPersistent: false, lockoutOnFailure: false);

                if (resultado.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(request.UserName);
                    response.Success = true;
                    response.Data = await ConstruirToken(user);
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = "Credenciales incorrectas.";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        private async Task<LoginResponseDto> ConstruirToken(ApplicationUser user)
        {
            //creamos los claims, que son informaciones emitidas por una fuente confiable, pueden contener cualquier key/value que definamos y que son añadidas al TOKEN
            var claims = new List<Claim>()
           {
               new Claim(ClaimTypes.Email,user.Email ?? string.Empty), //Nunca enviar data sensible en un claim, ya que es leído por el cliente
               new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}")
           };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //firmando el JWT
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Jwt.JWTKey)); //nos valemos del proveedor de configuracion appsettings.Development.json para guardar una llaveJWT
            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddSeconds(options.Value.Jwt.LifetimeInSeconds);//se puede configurar cualquier espacio de tiempo de validez de un token según las reglas de negocio

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, signingCredentials: credenciales, expires: expiracion);
            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                ExpirationDate = expiracion,
                Roles=roles.ToList()
            };
        }

       
        public async Task<BaseResponse> RequestTokenToResetPasswordAsync(ResetPasswordRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var userIdentity = await userManager.FindByEmailAsync(request.Email);
                if (userIdentity is null)
                {
                    throw new SecurityException("Usuario no existe");
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(userIdentity);

                // Enviar un email con el token para reestablecer la contraseña
                await emailService.SendEmailAsync(request.Email, "Reestablecer clave",
                    @$"
                    <p> Estimado {userIdentity.FirstName} {userIdentity.LastName}</p>
                    <p> Para reestablecer su clave, por favor copie el siguiente codigo</p>
                    <p> <strong> {token} </strong> </p>
                    <hr />
                    Atte. <br />
                    Tramite Goreu © 2024
                ");

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al solicitar el token para resetear la clave";
                logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }


        public async Task<BaseResponse> ResetPasswordAsync(NewPasswordRequestDto request)
        {
            var response = new BaseResponse();

            try
            {
                var userIdentity = await userManager.FindByEmailAsync(request.Email);

                if (userIdentity is null)
                {
                    throw new ApplicationException("Usuario no existe");
                }

                var result = await userManager.ResetPasswordAsync(userIdentity, request.Token, request.ConfirmNewPassword);
                response.Success = result.Succeeded;

                if (!result.Succeeded)
                {

                    response.ErrorMessage = string.Join(" ", result.Errors.Select(x => x.Description).ToArray());
                }
                else
                {
                    //Enviar un email de confirmacion de clave cambiada
                    await emailService.SendEmailAsync(request.Email,"Confiracion de cambio de clave",
                    @$"
                    <P> Estimado {userIdentity.FirstName} {userIdentity.LastName}</p>
                    <p> Se ha cambiado su clave corecctaente</p>
                    <hr />
                    Atte. <br />
                    Tramite Goreu @ 2024");
                }
            }
            catch (Exception ex)
            {
                
                response.ErrorMessage = "Ocurrio un error al resetear el Password";
                logger.LogError(ex, "{ErrorMessage} {Message}",response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> ChangePasswordAsync(string email, ChangePasswordRequestDto request)
        {
            var response = new BaseResponse();

            try
            {
                var userIdentity = await userManager.FindByEmailAsync(email);

                if (userIdentity is null)
                {
                    throw new ApplicationException("Usuario no existe");
                }

                var result = await userManager.ChangePasswordAsync(userIdentity, request.OldPassword, request.NewPassword);
                response.Success = result.Succeeded;
                if (!result.Succeeded)
                {
                    response.ErrorMessage = string.Join(" ", result.Errors.Select(x => x.Description).ToArray());
                }
                else
                {
                    logger.LogInformation("Se cambio la clave para {email}", userIdentity.Email);
                    //Enviar un email de confirmacion de clave cambiada
                    await emailService.SendEmailAsync(email, "Confiracion de cambio de clave",
                    @$"
                    <P> Estimado {userIdentity.FirstName} {userIdentity.LastName}</p>
                    <p> Se ha cambiado su clave corecctaente</p>
                    <hr />
                    Atte. <br />
                    Tramite Goreu @ 2024");
                }
            }
            catch (Exception ex) 
            {
                
                response.ErrorMessage = "Error al cambiar la clave";
                logger.LogError(ex, "Error al cambiar password {Message}", ex.Message);
            }

            return response;
        }
        //---------------------------------------------------------------------------------------------
        public async Task<BaseResponseGeneric<List<UserResponseDto>>> GetUsersByRole(string? role)
        {
            var response = new BaseResponseGeneric<List<UserResponseDto>>();
            try
            {
                List<ApplicationUser> resultado = new();
                if (role.Length > 0)
                {

                    resultado = (await userManager.GetUsersInRoleAsync(role)).ToList();//trae los user por role
                }
                else {
                    resultado = await context.Users.ToListAsync(); //trae a todos los user
                
                }

                var listResponse = new List<UserResponseDto>();
                foreach (var user in resultado) { 
                    var roles= await userManager.GetRolesAsync(user);
                    listResponse.Add(new UserResponseDto
                    {
                        Id=user.Id,
                        FirstName=user.FirstName,
                        LastName=user.LastName,
                        Email=user.Email ?? string.Empty,
                        Roles=roles.ToList()
                    });
                }
                if (resultado.Count > 0)
                {
                    response.Success = true;
                    response.Data = listResponse;
                }
                else {
                    response.ErrorMessage = "Ningun usuario encontrado.";
                    logger.LogWarning(response.ErrorMessage);
                }

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }


        public async Task<BaseResponseGeneric<UserResponseDto>> GetUserByEmail(string email)
        {
            var response = new BaseResponseGeneric<UserResponseDto>();
            try
            {
                var person =await userManager.Users.Where(x=>x.Email==email).FirstOrDefaultAsync();
                if (person is not null)
                {
                    var roles = await userManager.GetRolesAsync(person);
                    var personDto = new UserResponseDto
                    {
                        Id = person.Id,
                        Email = person.Email ?? string.Empty,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Roles = roles.ToList()
                    };
                    response.Success = true;
                    response.Data = personDto;

                }
                else
                {
                    response.ErrorMessage = "Ningun usuario encontrado.";
                    logger.LogWarning(response.ErrorMessage);

                }

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> CreateRoleAsync(string roleName)
        {
            var response = new BaseResponse();
            try
            {
                if (await roleManager.RoleExistsAsync(roleName))
                {
                    response.ErrorMessage = "Rol ya existe";
                    return response;
                }
                var resultado = await roleManager.CreateAsync(new IdentityRole(roleName.ToUpper()));

                if (resultado.Succeeded)
                {
                    response.Success = true;
                }
                else
                {
                    response.ErrorMessage = string.Join(" ", resultado.Errors.Select(x => x.Description).ToArray());
                    logger.LogWarning(response.ErrorMessage);
                }

                return response;

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error al registrar el rol";
                logger.LogError(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteRoleAsync(string roleName)
        {
            var response = new BaseResponse();

            try
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role is null ) 
                {
                    response.ErrorMessage = " Rol no encontrado";
                    return response;

                }

                var resultado=await roleManager.DeleteAsync(role);
                if (resultado.Succeeded)
                {
                    response.Success = true;
                }
                else
                {
                    response.ErrorMessage = string.Join(" ",resultado.Errors.Select(x=>x.Description).ToArray());
                    logger.LogWarning(response.ErrorMessage);
                }

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Error al borrar Role";
                logger.LogError(ex,"{ErrorMessage}{Message}",response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseGeneric<List<RoleResponseDto>>> GetRolesAsync()
        {
            var response = new BaseResponseGeneric<List<RoleResponseDto>>();

            try
            {
                var rolesData = await roleManager.Roles.Select(x => new RoleResponseDto
                {
                    Id=x.Id,
                    Name=x.Name ?? string.Empty,
                    NormalizedName=x.NormalizedName ??string.Empty
                }).ToListAsync();

                if (rolesData is not null)
                {
                    response.Success = true;
                    response.Data = rolesData;
                }
                else
                {
                    response.ErrorMessage = "ningun rol Encontrado";
                    logger.LogWarning(response.ErrorMessage);
                }

            }
            catch (Exception ex)
            {

                response.ErrorMessage = "ocurrio un error";
                logger.LogError(ex, "{ErrorMessage}{MEssage}",response.ErrorMessage, ex.Message );
            }


            return response;
        }

        public async Task<BaseResponse> GrantUserRole(string userId, string roleName)
        {
            var response = new BaseResponse();

            try
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user is null) 
                {
                    response.ErrorMessage = "usuario no enocntrado";
                    return response;
                }

                //verifica si existe el rol
                var roleExistis = await roleManager.RoleExistsAsync(roleName);
                if (!roleExistis) 
                {
                    response.ErrorMessage = "Rol no Existe";
                    return response;
                }
                //verificar si el user tiene el rol
                var userRoleExists = await userManager.IsInRoleAsync(user, roleName);
                if (userRoleExists) {
                    response.ErrorMessage = "ya cuenta con este rol";
                    return response;
                }

                //agregar el rol
                var resultado = await userManager.AddToRoleAsync(user, roleName);
                if (resultado.Succeeded)
                {
                    response.Success = true;

                }
                else 
                {
                    response.ErrorMessage = string.Join(" ", resultado.Errors.Select(x =>x.Description).ToArray());
                    logger.LogWarning(response.ErrorMessage);
                
                }


            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error al agregar Rol al Usuario";
                logger.LogError(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> GrantUserRoleByEmail(string email, string roleName)
        {
            var response = new BaseResponse();

            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user is null)
                {
                    response.ErrorMessage = "usuario no enocntrado";
                    return response;
                }
                var roleExistis = await roleManager.RoleExistsAsync(roleName);
                if (!roleExistis)
                {
                    response.ErrorMessage = "Rol no Existe";
                    return response;
                }
                //verificar si el user tiene el rol
                var userRoleExists = await userManager.IsInRoleAsync(user, roleName);
                if (userRoleExists)
                {
                    response.ErrorMessage = "ya cuenta con este rol";
                    return response;
                }

                //agregar el rol
                var resultado = await userManager.AddToRoleAsync(user, roleName);
                if (resultado.Succeeded)
                {
                    response.Success = true;

                }
                else
                {
                    response.ErrorMessage = string.Join(" ", resultado.Errors.Select(x => x.Description).ToArray());
                    logger.LogWarning(response.ErrorMessage);

                }


            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocurrio un error al agregar Rol al Usuario";
                logger.LogError(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> RevokeUserRoles(string userId)
        {
            var response = new BaseResponse();

            try
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user is null) 
                {
                    response.ErrorMessage = "usuario no encontrado";
                    return response;
                }
                var roles = await userManager.GetRolesAsync(user);
                var resultado = await userManager.RemoveFromRolesAsync(user, roles);
                if (resultado.Succeeded)
                {
                    response.Success = true;

                }
                else 
                {
                    response.ErrorMessage = string.Join(" ", resultado.Errors.Select(x => x.Description).ToArray());
                    logger.LogWarning(response.ErrorMessage);
                }


            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocuarrio un error al quitar roles";
                logger.LogError(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> RevokeUserRole(string userId, string roleName)
        {
            var response = new BaseResponse();

            try
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user is null)
                {
                    response.ErrorMessage = "usuario no encontrado";
                    return response;
                }
               
                var resultado = await userManager.RemoveFromRoleAsync(user, roleName);
                if (resultado.Succeeded)
                {
                    response.Success = true;

                }
                else
                {
                    response.ErrorMessage = string.Join(" ", resultado.Errors.Select(x => x.Description).ToArray());
                    logger.LogWarning(response.ErrorMessage);
                }


            }
            catch (Exception ex)
            {

                response.ErrorMessage = "Ocuarrio un error al quitar rol";
                logger.LogError(ex, "{ErrorMessage}{Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
/// en las peticiones http , ¿cuando es necesario poner un atributo en 
/// el url como "{userId}"?, atributo en [HttpPost("/{userId}/roles/grant")], del metodo GrantUserRole, 
/// ¿solo cuando se va hacer una busqueda con ese atributo?
/// lo digo porque tambien se hace una busqueda con el atributo roleName dentro de esa api
