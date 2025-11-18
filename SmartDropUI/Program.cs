using Blazored.LocalStorage;
using SmartDropUI.Services;
using SmartDropUI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ URL BASE de la API
var apiBaseUrl = "https://localhost:5001"; // ⚠️ Ajusta el puerto si es diferente

// ✅ HttpClient para ApiService
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// ✅ HttpClient para HistorialRiegoService
builder.Services.AddHttpClient<HistorialRiegoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// ✅ HttpClient para AuthService (ESTE FALTABA)
builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// ✅ HttpClient para RiegoService
builder.Services.AddHttpClient<RiegoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// ✅ Registrar servicios (sin HttpClient explícito, ya se inyectan arriba)
builder.Services.AddScoped<ClimaService>();

// ✅ Registrar ArduinoService como singleton con HistorialRiegoService
builder.Services.AddSingleton<ArduinoService>(sp =>
{
    var historialService = sp.GetRequiredService<HistorialRiegoService>();
    var arduino = new ArduinoService("COM11", 9600, historialService);
    arduino.Conectar();
    return arduino;
});

// ✅ LocalStorage
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