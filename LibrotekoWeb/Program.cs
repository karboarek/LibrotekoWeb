/*using LibrotekoApp.Models;
using LibrotekoWeb.Middleware;
using LibrotekoWeb.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Dodaj obsługę lokalizacji
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, SendGridEmailService>();
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddSingleton<SmtpEmailService>();




// Lista obsługiwanych języków
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("pl"),
    new CultureInfo("da")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddRazorPages();

var app = builder.Build();

var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(locOptions);
app.UseMiddleware<LoggingMiddleware>();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run(); */

using LibrotekoApp.Models;
using LibrotekoWeb.Middleware;
using LibrotekoWeb.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Dodaj obsługę lokalizacji
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddSingleton<SmtpEmailService>();

// Konfiguracja CORS - Dodanie polityki
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Zezwalaj na zapytania z dowolnego źródła
              .AllowAnyMethod() // Zezwalaj na dowolne metody HTTP (GET, POST, itp.)
              .AllowAnyHeader(); // Zezwalaj na dowolne nagłówki
    });
});

// Lista obsługiwanych języków
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("pl"),
    new CultureInfo("da")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddRazorPages();


var app = builder.Build();

var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(locOptions);

// Middleware logowania
app.UseMiddleware<LoggingMiddleware>();

// Statyczne pliki
app.UseStaticFiles();

// Routing
app.UseRouting();

// Włączenie CORS w aplikacji
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapRazorPages();

app.Run();



