var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar la serialización JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Para evitar la conversión a camelCase
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; // Ignorar valores nulos
    });

// Agregar servicio CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
       builder => builder
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddServices();

var app = builder.Build();

// Habilitar el uso de CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Otras configuraciones
app.UseRouting();

app.MapControllers();

app.Run();
