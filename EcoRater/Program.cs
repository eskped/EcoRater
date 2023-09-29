using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcoRater.Data;
using EcoRater.Interfaces;
using EcoRater.Services;
using Microsoft.Azure.AppConfiguration.AspNetCore;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configure Azure Key Vault
var keyVaultUri = builder.Configuration["KeyVaultUri"];
Console.WriteLine("\n\n\n keyvaulturi: {0}", keyVaultUri);

if (string.IsNullOrEmpty(keyVaultUri))
{
    throw new InvalidOperationException("KeyVaultUri configuration is missing");
}
var credential = new DefaultAzureCredential();

var secretClient = new SecretClient(new Uri(keyVaultUri), credential);


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
