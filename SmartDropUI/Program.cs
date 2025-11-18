using Blazored.LocalStorage;
using SmartDropUI.Services;
using SmartDropUI.Components;  // ✅ AGREGAR ESTA LÍNEA

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// HttpClient para consumir RiegoAPI
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Registrar servicios
builder.Services.AddScoped<RiegoService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ClimaService>();

// Registrar ArduinoService como singleton
builder.Services.AddSingleton<ArduinoService>(sp =>
{
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

// ✅ Ahora App está disponible gracias al using SmartDropUI.Components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();