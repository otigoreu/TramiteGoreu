using Microsoft.EntityFrameworkCore;
using TramiteGoreu.Persistence;
using TramiteGoreu.Repositories;
using TramiteGoreu.Services.Interface;
using TramiteGoreu.Services.Iplementation;
using TramiteGoreu.Services.profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1.register or configure my context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});
//Settings context
builder.Services.AddHttpContextAccessor();

//2. registering y services
//builder.Services.AddSingleton<PersonRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<IPersonService, PersonService>();


builder.Services.AddAutoMapper(config =>
{
    //configuring the mapping perfiles
    config.AddProfile<PersonProfile>();

});
//CORS
var corsConfiguration = "TramiteGoreuCors";
builder.Services.AddCors(setup =>
{
    setup.AddPolicy(corsConfiguration, policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader().WithExposedHeaders(new string[] { "TotalRecordsQuantity" });
        policy.AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
