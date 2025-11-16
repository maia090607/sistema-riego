using Blazored.LocalStorage;
using SmartDropUI.Components;
using SmartDropUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configurar HttpClientFactory para múltiples clientes
builder.Services.AddHttpClient();

// HttpClient principal para la API de riego
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

// Registrar servicios
builder.Services.AddScoped<RiegoService>();
builder.Services.AddScoped<AuthService>();

// LocalStorage
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
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