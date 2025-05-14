using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Data.Repositories;
using TravSystem.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<TravellerDBContext>();

builder.Services.AddScoped<ITPlanetRepository, TPlanetRepository>();
builder.Services.AddScoped<ITAtmopshereRepository, TAtmosphereRepository>();
builder.Services.AddScoped<ITGovernmentRepository, TGovernmentRepository>();
builder.Services.AddScoped<ITLawLevelRepository, TLawLevelRepository>();
builder.Services.AddScoped<ITStarportRepository, TStarportRepository>();
builder.Services.AddScoped<ITSubSectorRepository, TSubSectorRepository>();
builder.Services.AddScoped<ITSystemRepository, TSystemRepository>();
builder.Services.AddScoped<ITBaseRepository, TBaseRepository>();
builder.Services.AddScoped<ITradeClassificationRepository, TradeClassificationRepository>();
builder.Services.AddScoped<ITTravelCodeRepository, TTravelCodeRepository>();

builder.Services.AddScoped<IUtilitlityService, UtilityService>();
builder.Services.AddScoped<ITPlanetGenService, TPlanetGenService>();    
builder.Services.AddScoped<ITradeClassiificationService, TradeClassificationService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TravellerDBContext >();

    // Check and apply pending migrations
    var pendingMigrations = dbContext.Database.GetPendingMigrations();
    if (pendingMigrations.Any())
    {
        Console.WriteLine("Applying pending migrations...");
        dbContext.Database.Migrate();
        Console.WriteLine("Migrations applied successfully.");
    }
    else
    {
        Console.WriteLine("No pending migrations found.");
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
