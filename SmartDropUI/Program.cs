using Blazored.LocalStorage;
using SmartDropUI.Services;
using SmartDropUI.Components;

var builder = WebApplication.CreateBuilder(args);

// Agregar componentes Razor (Blazor Server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ============================================================
// 1. CONFIGURACIÓN DE LA API (URL BASE)
// ============================================================
// Intenta leer desde appsettings.json, si no existe usa el valor por defecto
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:5001";

Console.WriteLine($"🔌 Configurando servicios HTTP apuntando a: {apiBaseUrl}");

// ============================================================
// 2. INYECCIÓN DE SERVICIOS HTTP (CLIENTES)
// ============================================================

// Servicio para Arduino (Control manual, estado)
builder.Services.AddHttpClient<ArduinoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30); // Timeout para evitar bloqueos largos
});

// Servicio General de API (Usuarios, Plantas, Temperatura)
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Servicio de Historial de Riego
builder.Services.AddHttpClient<HistorialRiegoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Servicio de Autenticación (Login, Registro)
builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Servicio de Riego (Lógica general)
builder.Services.AddHttpClient<RiegoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// ============================================================
// 3. OTROS SERVICIOS
// ============================================================

// Servicio del Clima (Usa OpenWeatherMap, se registra como Scoped)
builder.Services.AddScoped<ClimaService>();

// LocalStorage para guardar la sesión del usuario
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// ============================================================
// 4. CONFIGURACIÓN DEL PIPELINE HTTP
// ============================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

Console.WriteLine("════════════════════════════════════════════════════");
Console.WriteLine("  🌱 SmartDrop UI - Sistema de Riego Iniciado");
Console.WriteLine($"  🌐 UI: http://localhost:5144");
Console.WriteLine($"  🔌 API Conectada: {apiBaseUrl}");
Console.WriteLine("════════════════════════════════════════════════════");

app.Run();