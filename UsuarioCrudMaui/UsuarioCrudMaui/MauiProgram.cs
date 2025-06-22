using Microsoft.Extensions.Logging;
using UsuarioCrudMaui.Services;
using UsuarioCrudMaui.ViewModels;
using UsuarioCrudMaui.Views;

namespace UsuarioCrudMaui;

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

        builder.Services.AddSingleton<UsuarioService>();

        builder.Services.AddSingleton<UsuariosViewModel>();
        builder.Services.AddTransient<UsuarioFormViewModel>();

        builder.Services.AddSingleton<UsuariosPage>();
        builder.Services.AddTransient<UsuarioFormPage>();

        Routing.RegisterRoute(nameof(UsuarioFormPage), typeof(UsuarioFormPage));

        return builder.Build();
    }
}
