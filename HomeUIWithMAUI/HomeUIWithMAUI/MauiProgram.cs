using HomeUIWithMAUI.Data;
using HomeUIWithMAUI.Models;
using HomeUIWithMAUI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeUIWithMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Add the DbContext to the services
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=localdatabase.db"));

            // Register the Device Service
            builder.Services.AddScoped<IDeviceService, DeviceService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // Apply migrations and seed the database at startup
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                try
                {
                    // Apply migrations
                    dbContext.Database.Migrate();

                    // Seed the database
                    SeedDatabase(dbContext);
                    Console.WriteLine("Database initialized and seeded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during migration or seeding: {ex.Message}");
                }
            }

            return app;
        }

        private static void SeedDatabase(ApplicationDbContext context)
        {
            // Seed Thermostats
            if (!context.Thermostats.Any())
            {
                context.Thermostats.Add(new Thermostat
                {
                    DeviceId = 1,
                    CurrentTemperature = 72,
                    CurrentState = State.Off
                });
            }

            // Seed SmartLocks
            if (!context.SmartLocks.Any())
            {
                context.SmartLocks.Add(new SmartLock
                {
                    DeviceId = 1,
                    CurrentState = State.Off,
                    IsLocked = true
                });
            }

            // Save changes
            context.SaveChanges();
        }
    }
}
