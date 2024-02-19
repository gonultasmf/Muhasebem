namespace Muhasebem;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider services)
    {
        this
        .ItemsFmg(
            new FlyoutItem()
            .FlyoutItemIsVisibleFmg(false)
            .RouteFmg(nameof(LoginPage))
            .ItemsFmg(services.GetService<LoginPage>()),

            new FlyoutItem()
            .FlyoutItemIsVisibleFmg(false)
            .RouteFmg(nameof(HomePage))
            .ItemsFmg(services.GetService<HomePage>())
        );
    }
}
