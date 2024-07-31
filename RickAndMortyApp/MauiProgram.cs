using Microsoft.Extensions.Logging;
using RickAndMortyApp.Data.Source.Remote.Api;
using RickAndMortyApp.Domain.Repository;
using RickAndMortyApp.Presentation.ViewModels;
using RickAndMortyApp.Presentation.Views;

namespace RickAndMortyApp
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
            builder.Services.AddSingleton<ICharacterRepository, CharacterRepository>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<CharacterDetailViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CharacterDetailPage>();

            var app = builder.Build();
            App.InitializeServiceProvider(app.Services);
            return app;
        }
    }
}
