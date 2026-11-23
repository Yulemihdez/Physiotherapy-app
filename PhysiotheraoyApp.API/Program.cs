using PhysiotherapyApp.Application;
using PhysiotherapyApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Registrar controladores
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// Registrar las dependencias de las capas
builder.Services.AddApplication();

builder.Services.AddInfrastructure(
    builder.Configuration);

// Construir la aplicación
var app = builder.Build();

// Publicar el documento OpenAPI en desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Middleware
app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

// Iniciar la aplicación
app.Run();
