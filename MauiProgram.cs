using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Notes.Common;
using Notes.Services;

namespace Notes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Notes.db3");

            builder.Services.AddSingleton(new NotesDatabase(dbPath));

            #if DEBUG
            builder.Logging.AddDebug();
            #endif

            Startup.ServiceProvider = builder.Services.BuildServiceProvider();


            return builder.Build();
        }
    }
}
