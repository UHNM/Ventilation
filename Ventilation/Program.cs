using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using DAL.Contexts;
using DAL.Repositories;
using DAL.Repositories.DefaultImplementations;
using System.Globalization;
using Ventilation.Components;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IVentilationContext, VentilationContext>();


//Repositories
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IPatientListRepository, PatientListRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();


//Managers
builder.Services.AddScoped<IEquipmentManager, EquipmentManager>();
builder.Services.AddScoped<IPatientListManager, PatientListManager>();
builder.Services.AddScoped<IPatientManager, PatientManager>();
builder.Services.AddScoped<IStockManager, StockManager>();
builder.Services.AddScoped<ILoanManager, LoanManager>();


builder.Services.AddLocalization();
builder.Services.AddBlazorBootstrap();
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
//CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");

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
app.UseRequestLocalization("en-GB");
//app.UseRequestLocalization(new RequestLocalizationOptions()
//    .AddSupportedCultures(new[] { "en-GB" })
//    .AddSupportedUICultures(new[] { "en-GB" }));


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
