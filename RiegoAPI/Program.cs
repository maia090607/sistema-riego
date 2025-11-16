using BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// ===========================
// CONFIGURACIÓN DE SERVICIOS
// ===========================

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI para documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartDrop - Sistema de Riego Automático",
        Version = "v1",
        Description = "API RESTful para el sistema de riego automático con Arduino.",
        Contact = new OpenApiContact
        {
            Name = "Equipo de Desarrollo",
            Email = "contacto@smartdrop.com",
            Url = new Uri("https://smartdrop.com")
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

// Configuración de HttpClient global
builder.Services.AddHttpClient();

// HttpClient específico para OpenWeather
builder.Services.AddHttpClient("OpenWeather", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
    client.Timeout = TimeSpan.FromSeconds(10);
});

// ===================================
// REGISTRAR SERVICIOS DE LA CAPA BLL
// ===================================

builder.Services.AddScoped<ServiciosPlanta>();
builder.Services.AddScoped<ServicioHistorial>();
builder.Services.AddScoped<ServiciosUsuario>();
builder.Services.AddScoped<ServiciosAlertas>();
builder.Services.AddScoped<ServicioClima>();
builder.Services.AddScoped<ServiciosHumedad>();
builder.Services.AddScoped<ServicioGraficas>();

// Servicio Singleton para puerto serial
builder.Services.AddSingleton<ServicioPuerto>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    string puerto = config.GetValue<string>("SerialPort:Puerto") ?? "COM3";
    int baudRate = config.GetValue<int>("SerialPort:BaudRate", 9600);
    return new ServicioPuerto(puerto, baudRate);
});

// Habilitar archivos estáticos
builder.Services.AddDirectoryBrowser();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("https://localhost:5001", "http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Usar CORS
app.UseCors("AllowBlazor");

// ===================================
// CONFIGURACIÓN DEL PIPELINE HTTP
// ===================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartDrop API v1");
        c.DocumentTitle = "SmartDrop - API de Riego Automático";
        c.RoutePrefix = "swagger"; // /swagger
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Ruta base hacia Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

// ===================================
// MANEJO GLOBAL DE ERRORES
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
// INICIO DE LA APLICACIÓN
// ===================================

Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║     🌱 API SISTEMA DE RIEGO AUTOMÁTICO - SMARTDROP        ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
Console.WriteLine();
Console.WriteLine($"🌐 API: https://localhost:5001");
Console.WriteLine($"📚 Swagger: https://localhost:5001/swagger");
Console.WriteLine($"🔌 Puerto Serial: {app.Configuration.GetValue<string>("SerialPort:Puerto")}");
Console.WriteLine();
Console.WriteLine("Presiona Ctrl+C para detener el servidor...");
Console.WriteLine();

app.Run();
