using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcoRater.Data;
using EcoRater.Interfaces;
using EcoRater.Services;
using Microsoft.Azure.AppConfiguration.AspNetCore;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configure Azure App Configuration
// var appConfigConnection = builder.Configuration.GetConnectionString("AppConfig");
// builder.Configuration.AddAzureAppConfiguration(options =>
// {
//    options.Connect(appConfigConnection).UseFeatureFlags();
//});

// Configure Azure Key Vault
var keyVaultUri = builder.Configuration["KeyVaultUri"];
var credential = new DefaultAzureCredential();
builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), credential);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IOpenAIService, OpenAIService>();
builder.Services.AddHttpClient<OpenAIService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Database migration logic for production
if (app.Environment.IsProduction())
{
    using (var serviceScope = app.Services.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}

app.Run();
