namespace Muhasebem;

public partial class App : Application
{
    public App(IServiceProvider services)
    {
        _ = services.GetService<Initilazer>();
        this
            .ResourcesFmg(AppStyles.Default)
            .MainPageFmg(services.GetService<LoginPage>());
    }
}
