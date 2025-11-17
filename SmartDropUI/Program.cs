using Blazored.LocalStorage;
using SmartDropUI.Components;
using SmartDropUI.Services;

var builder = WebApplication.CreateBuilder(args);

// ===================================
// SERVICIOS DE BLAZOR
// ===================================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ===================================
// HTTP CLIENTS
// ===================================
builder.Services.AddHttpClient();

// Configurar HttpClient para consumir la API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7001") // URL de tu RiegoAPI
});

// HttpClient para la API del clima (Open-Meteo)
builder.Services.AddHttpClient("WeatherAPI", client =>
{
    client.BaseAddress = new Uri("https://api.open-meteo.com/");
    client.Timeout = TimeSpan.FromSeconds(10);
});

// ===================================
// SERVICIOS DE LA APLICACIÓN
// ===================================
builder.Services.AddScoped<RiegoService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<PlantaService>();

// ===================================
// LOCAL STORAGE
// ===================================
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// ===================================
// CONFIGURACIÓN DEL PIPELINE
// ===================================
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

app.Run();