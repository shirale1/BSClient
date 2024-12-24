using BSClient.Services;
using BSClient.ViewModels;
using BSClient.Views;
using Microsoft.Extensions.Logging;

namespace BSClient
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
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<RegisterPageViewModel>();
            builder.Services.AddTransient<Admin>();
            builder.Services.AddTransient<AdminViewModel>();
            builder.Services.AddTransient<HomePageB>();
            builder.Services.AddTransient<HomePageBViewModel>();
            builder.Services.AddTransient<HomePageP>();
            builder.Services.AddTransient<HomePagePViewModel>();
            builder.Services.AddTransient<Tips>();
            builder.Services.AddTransient<TipsViewModel>();
            builder.Services.AddTransient<WaitingList>();
            builder.Services.AddTransient<WaitingListViewModel>();
            builder.Services.AddSingleton<BSWebAPIProxy>();
            builder.Services.AddTransient<AppShell>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
