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
            .ItemsFmg(services.GetService<LoginPage>())
        );
    }
}
