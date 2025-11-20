using Blazored.LocalStorage;
using SmartDropUI.Services;
using SmartDropUI.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ Leer URL de configuración
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:5001";

// ✅ HttpClient tipado para ArduinoService
builder.Services.AddHttpClient<ArduinoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// ✅ HttpClient tipado para otros servicios
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddHttpClient<HistorialRiegoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddHttpClient<RiegoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddScoped<ClimaService>();

// ✅ ELIMINADO: No registrar ArduinoService como Singleton
// El HttpClient tipado ya lo registra como Scoped automáticamente

builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

Console.WriteLine("════════════════════════════════════════════════════");
Console.WriteLine("  🌱 SmartDrop UI - Sistema de Riego");
Console.WriteLine("════════════════════════════════════════════════════");
Console.WriteLine($"🌐 Aplicación: http://localhost:5144");
Console.WriteLine($"🔌 API Backend: {apiBaseUrl}");
Console.WriteLine("════════════════════════════════════════════════════");

app.Run();
