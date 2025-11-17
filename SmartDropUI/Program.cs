using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SmartDropUI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Registrar servicios
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<RiegoService>();

// Agregar HttpClient
builder.Services.AddScoped<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();