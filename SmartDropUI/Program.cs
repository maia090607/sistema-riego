using Blazored.LocalStorage;
using SmartDropUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configurar HttpClient para consumir la API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7001") // URL de tu RiegoAPI
});

// Registrar servicios
builder.Services.AddScoped<RiegoService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ClimaService>();

// Registrar ArduinoService como singleton
builder.Services.AddSingleton<ArduinoService>(sp =>
{
    // ⚠️ CAMBIA "COM3" POR TU PUERTO REAL (ej: COM4, COM5, etc.)
    var arduino = new ArduinoService("COM11", 9600);
    arduino.Conectar();
    return arduino;
});

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

app.MapRazorComponents<SmartDropUI.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();