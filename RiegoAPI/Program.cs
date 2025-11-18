using BLL;
using RiegoAPI.Controllers;
using RiegoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// ===========================
// SERVICIOS BÁSICOS
// ===========================

builder.Services.AddSingleton<IArduinoService, ArduinoService>();
builder.Services.AddControllers();

// ✅ Swagger básico
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// HttpClient
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("OpenWeather", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
    client.Timeout = TimeSpan.FromSeconds(10);
});

// ===================================
// SERVICIOS DE LA CAPA BLL
// ===================================

builder.Services.AddScoped<ServiciosPlanta>();
builder.Services.AddScoped<ServicioHistorial>();
builder.Services.AddScoped<ServiciosUsuario>();
builder.Services.AddScoped<ServiciosAlertas>();
builder.Services.AddScoped<ServicioClima>();
builder.Services.AddScoped<ServiciosHumedad>();
builder.Services.AddScoped<ServicioGraficas>();

// Puerto Serial
builder.Services.AddSingleton<ServicioPuerto>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    string puerto = config.GetValue<string>("SerialPort:Puerto") ?? "COM3";
    int baudRate = config.GetValue<int>("SerialPort:BaudRate", 9600);
    return new ServicioPuerto(puerto, baudRate);
});

var app = builder.Build();

// ===================================
// PIPELINE HTTP
// ===================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Redirigir raíz a Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

Console.WriteLine("════════════════════════════════════════════════════");
Console.WriteLine("  🌱 API SMARTDROP - Sistema de Riego Automático");
Console.WriteLine("════════════════════════════════════════════════════");
Console.WriteLine($"🌐 API: https://localhost:7068");
Console.WriteLine($"📚 Swagger: https://localhost:7068/swagger");
Console.WriteLine($"🔌 Puerto Serial: {app.Configuration.GetValue<string>("SerialPort:Puerto")}");
Console.WriteLine("════════════════════════════════════════════════════");
Console.WriteLine();

app.Run();