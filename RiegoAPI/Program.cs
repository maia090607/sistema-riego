using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BLL;

var builder = WebApplication.CreateBuilder(args);

// ===========================
// CONFIGURACIÓN DE SERVICIOS
// ===========================

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI para documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Sistema de Riego Automático",
        Version = "v1",
        Description = "API RESTful para el sistema de riego automático con Arduino",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Equipo de Desarrollo",
            Email = "soporte@riego.com"
        }
    });
});

// Configurar CORS para permitir llamadas desde cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configurar HttpClient para llamadas a APIs externas (OpenWeatherMap)
builder.Services.AddHttpClient();

// ===================================
// REGISTRAR SERVICIOS DE LA CAPA BLL
// ===================================

// Servicios Scoped (se crean por cada request)
builder.Services.AddScoped<ServiciosPlanta>();
builder.Services.AddScoped<ServicioHistorial>();
builder.Services.AddScoped<ServiciosUsuario>();
builder.Services.AddScoped<ServiciosAlertas>();
builder.Services.AddScoped<ServicioClima>();
builder.Services.AddScoped<ServiciosHumedad>();
builder.Services.AddScoped<ServicioGraficas>();

// Servicio Singleton (única instancia compartida) para el puerto serial
builder.Services.AddSingleton<ServicioPuerto>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    string puerto = configuration.GetValue<string>("SerialPort:Puerto") ?? "COM3";
    int baudRate = configuration.GetValue<int>("SerialPort:BaudRate", 9600);

    return new ServicioPuerto(puerto, baudRate);
});

// Configurar archivos estáticos (para servir imágenes)
builder.Services.AddDirectoryBrowser();

var app = builder.Build();

// ===================================
// CONFIGURACIÓN DEL PIPELINE HTTP
// ===================================

// Habilitar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Riego v1");
        options.RoutePrefix = "swagger"; // Acceder en /swagger
    });
}

// Redirigir HTTP a HTTPS
app.UseHttpsRedirection();

// Habilitar archivos estáticos (wwwroot)
app.UseStaticFiles();

// Habilitar CORS
app.UseCors("AllowAll");

// Autenticación y autorización (si se implementa en el futuro)
app.UseAuthentication();
app.UseAuthorization();

// Mapear controladores
app.MapControllers();

// Página de inicio personalizada (opcional)
app.MapGet("/", () => Results.Redirect("/swagger"));

// ===================================
// MANEJO DE ERRORES GLOBAL
// ===================================
app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext context) =>
{
    return Results.Problem(
        title: "Ha ocurrido un error en el servidor",
        statusCode: StatusCodes.Status500InternalServerError
    );
});

// ===================================
// EJECUTAR LA APLICACIÓN
// ===================================

Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║     🌱 API SISTEMA DE RIEGO AUTOMÁTICO 🌱                ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
Console.WriteLine();
Console.WriteLine($"🌐 API corriendo en: https://localhost:5001");
Console.WriteLine($"📚 Documentación Swagger: https://localhost:5001/swagger");
Console.WriteLine($"🔌 Puerto Serial: {app.Configuration.GetValue<string>("SerialPort:Puerto")}");
Console.WriteLine();
Console.WriteLine("Presiona Ctrl+C para detener el servidor...");
Console.WriteLine();

app.Run();