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