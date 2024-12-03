using Goreu.Tramite.Persistence;
using Goreu.Tramite.Repositories.Implementacion;
using Goreu.Tramite.Repositories.Interfaces;
using Goreu.Tramite.Services.Interface;
using Goreu.Tramite.Services.Iplementation;
using Goreu.Tramite.Services.profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

using TramiteGoreu.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1.register or configure my context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});
//5.Settings context
builder.Services.AddHttpContextAccessor();

//9. patron deopciones
builder.Services.Configure<AppSettings>(builder.Configuration);


//6.identity
////builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddIdentity<Usuario, IdentityRole>(polices =>
{
    polices.Password.RequireDigit = true;
    polices.Password.RequiredLength = 6;
    polices.User.RequireUniqueEmail = true;


})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//jwt
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:JWTKey"] ??
        throw new InvalidOperationException("JWT key not configured"));
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
builder.Services.AddAuthorization();

//2. registering y services
//builder.Services.AddSingleton<PersonRepository>();
builder.Services.AddTransient<IPersonaRepository, PersonaRepository>();
builder.Services.AddTransient<IAplicacionRepository, AplicacionRepository>();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<ISedeRepository, SedeRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();


builder.Services.AddTransient<IPersonaService, PersonaService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IMenuService, MenuService>();
builder.Services.AddTransient<ISedeService, SedeService>();
builder.Services.AddTransient<IAplicacionService, AplicacionService>();

//3.register mapper
builder.Services.AddAutoMapper(config =>
{
    //configuring the mapping perfiles
    config.AddProfile<PersonaProfile>();
    config.AddProfile<AplicacionProfile>();
    config.AddProfile<MenuProfile>();
    config.AddProfile<SedeProfile>();


});

builder.Services.AddTransient<UserDataSeeder>();

//4. CORS
var corsConfiguration = "tramitegoreucors";
builder.Services.AddCors(setup =>
{
    setup.AddPolicy(corsConfiguration, policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader().WithExposedHeaders(new string[] { "totalrecordsquantity" });
        policy.AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Advanced Swagger configuration
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Goreu.Tramite.API",
            Description = "This is the documentation for my api in Goreu.",
            Version= "v1"
        });
    config.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "Goreu.Tramite API Swagger");
        config.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(corsConfiguration);

app.MapControllers();
// Aplicar migraciones y sembrar datos (asíncronamente)
await ApplyMigrationsAndSeedDataAsync(app);

app.Run();

static async Task ApplyMigrationsAndSeedDataAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (dbContext.Database.GetPendingMigrations().Any())
    {
        await dbContext.Database.MigrateAsync();
    }

    var userDataSeeder = scope.ServiceProvider.GetRequiredService<UserDataSeeder>();
    await userDataSeeder.SeedAsync();
}