using BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// ===========================
// CONFIGURACIÓN DE SERVICIOS
// ===========================

// Controladores
builder.Services.AddControllers();

// Swagger / OpenAPI (solo una configuración, como pediste)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartDrop - Sistema de Riego Automático",
        Version = "v1",
        Description = @"
API RESTful para el sistema de riego automático con Arduino.

**Contacto:** Equipo de Desarrollo",
        Contact = new OpenApiContact
        {
            Name = "Equipo de Desarrollo",
            Email = "contacto@smartdrop.com",
            Url = new Uri("https://smartdrop.com")
        }
    });
});

// ===========================
// CORS
// ===========================

// Solo una configuración de CORS (limpia y funcional)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("https://localhost:5001", "http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    // Política general si la necesitas
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// HTTP Clients
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("OpenWeather", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
    client.Timeout = TimeSpan.FromSeconds(10);
});

// ===========================
// SERVICIOS BLL
// ===========================
builder.Services.AddScoped<ServiciosPlanta>();
builder.Services.AddScoped<ServicioHistorial>();
builder.Services.AddScoped<ServiciosUsuario>();
builder.Services.AddScoped<ServiciosAlertas>();
builder.Services.AddScoped<ServicioClima>();
builder.Services.AddScoped<ServiciosHumedad>();
builder.Services.AddScoped<ServicioGraficas>();

// Puerto serial - Singleton
builder.Services.AddSingleton<ServicioPuerto>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    string puerto = config.GetValue<string>("SerialPort:Puerto") ?? "COM3";
    int baudRate = config.GetValue<int>("SerialPort:BaudRate", 9600);
    return new ServicioPuerto(puerto, baudRate);
});

// Archivos estáticos
builder.Services.AddDirectoryBrowser();

var app = builder.Build();

// ===============================
// MIDDLEWARE
// ===============================

// Aplicar CORS específico para Blazor
app.UseCors("AllowBlazor");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartDrop API v1");
        c.DocumentTitle = "SmartDrop - API de Riego Automático";

        // Ruta del Swagger
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

// Controladores
app.MapControllers();

// Redirección base a Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

// ===============================
// MANEJO GLOBAL DE ERRORES
// ===============================
app.UseExceptionHandler("/error");

app.Map("/error", (HttpContext context) =>
{
    return Results.Problem(
        title: "Ha ocurrido un error en el servidor",
        statusCode: StatusCodes.Status500InternalServerError
    );
});

// ===============================
// CONSOLA DEL SERVIDOR
// ===============================
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
