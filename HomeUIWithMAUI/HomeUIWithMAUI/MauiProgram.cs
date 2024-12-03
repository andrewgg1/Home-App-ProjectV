using HomeUIWithMAUI.Data;
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
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlite("Data Source=localdatabase.db"));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // Apply migrations at startup to ensure the database schema is up to date
            //using (var scope = app.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //    dbContext.Database.Migrate(); // Applies any pending migrations to the database
            //}

            return app;
        }
    }
}
