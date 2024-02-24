using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Muhasebem;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseSkiaSharp()
            .UseSimpleToolkit()
            .UseSimpleShell()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services
            .AddSingleton<App>()
            .AddSingleton<AppShell>()
            .AddSingleton<Initilazer>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScopedWithShellRoute<LoginPage, LoginPageViewModel>($"//{nameof(LoginPage)}")
            .AddScopedWithShellRoute<OperationsPage, OperationsPageViewModel>($"//{nameof(OperationsPage)}")
            .AddScopedWithShellRoute<DashboardPage, DashboardPageViewModel>($"//{nameof(DashboardPage)}")
            .AddScopedWithShellRoute<AccountPage, AccountPageViewModel>($"//{nameof(AccountPage)}")
            .AddScopedWithShellRoute<SettingsPage, SettingsPageViewModel>($"//{nameof(SettingsPage)}")
            .AddScopedWithShellRoute<HomePage, HomePageViewModel>($"//{nameof(HomePage)}");

        return builder.Build();
    }
}
