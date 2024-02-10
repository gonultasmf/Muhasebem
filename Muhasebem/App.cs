namespace Muhasebem;

public partial class App : Application
{
    public App(IServiceProvider services)
    {
        this
            .ResourcesFmg(AppStyles.Default)
            .MainPageFmg(services.GetService<LoginPage>());
    }
}
