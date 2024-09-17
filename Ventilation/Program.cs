using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using DAL.Contexts;
using DAL.Repositories;
using DAL.Repositories.DefaultImplementations;
using System.Globalization;
using Ventilation.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVentilationContext,VentilationContext>();

builder.Services.AddScoped<IEquipmentManager, EquipmentManager>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
