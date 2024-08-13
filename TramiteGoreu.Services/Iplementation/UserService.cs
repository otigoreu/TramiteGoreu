using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
        private readonly UserManager<TramiteGoreuUserIdentity> userManager;
        private readonly ILogger<UserService> logger;
        private readonly IOptions<AppSettings> options;
        private readonly IPersonaRepository personaRepository;
        private readonly SignInManager<TramiteGoreuUserIdentity> signInManager;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;

        public UserService(UserManager<TramiteGoreuUserIdentity> userManager, ILogger<UserService> logger,
            IOptions<AppSettings> options, IPersonaRepository personaRepository,
            SignInManager<TramiteGoreuUserIdentity> signInManager, IMapper mapper, IEmailService emailService)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.options = options;
            this.personaRepository = personaRepository;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public async Task<BaseResponseGeneric<RegisterResponseDto>> RegisterAsync(RegisterRequestDto request)
        {
            var response = new BaseResponseGeneric<RegisterResponseDto>();
            try
            {
                var user = new TramiteGoreuUserIdentity
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
                            ExpirationDate = tokenResponse.ExpirationDate
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
        private async Task<LoginResponseDto> ConstruirToken(TramiteGoreuUserIdentity user)
        {
            //creamos los claims, que son informaciones emitidas por una fuente confiable, pueden contener cualquier key/value que definamos y que son añadidas al TOKEN
            var claims = new List<Claim>()
           {
               new Claim(ClaimTypes.Email,user.Email), //Nunca enviar data sensible en un claim, ya que es leído por el cliente
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
                ExpirationDate = expiracion
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
                    Music Store © 2024
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
    }
}
