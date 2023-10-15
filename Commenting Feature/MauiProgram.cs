using Colour_UI_dbOnly;
using Colour_UI_dbOnly.Data;
using Colour_UI_dbOnly.ViewModels;
using Microsoft.Extensions.Logging;

namespace Colour_UI_dbOnly
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
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<CommentsViewModel>();

            builder.Services.AddSingleton<MainPage>();


            return builder.Build();
        }
    }
}