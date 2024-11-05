using Microsoft.Extensions.Logging;
using System.Diagnostics;

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

#if DEBUG
            Trace.WriteLine("Hello from MauiProgram!");
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
