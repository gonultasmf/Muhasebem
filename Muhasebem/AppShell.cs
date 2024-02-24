using Microsoft.Maui.Controls.Shapes;

namespace Muhasebem;

public partial class AppShell : SimpleShell
{
    TabBar tabBar;
    SimpleNavigationHost pageContainer;
    TabBarView tabBarView;
    Rectangle bottomBackgroundRectangle;
    public AppShell()
    {
        this
        .OnLoadedFmg(AppShellLoaded)
        .RootPageContainerFmg(
            new Grid()
            .IgnoreSafeAreaFmg(true)
            .ChildrenFmg(
                new SimpleNavigationHost()
                .AssignFmg(out pageContainer),

                new TabBarView()
                .AssignFmg(out tabBarView)
                .VerticalOptionsFmg(End)
                .HorizontalOptionsFmg(Fill)
                .InvokeOnElementFmg(e => e.CurrentPageSelectionChanged += TabBarViewCurrentPageChanged),

                new Rectangle()
                .AssignFmg(out bottomBackgroundRectangle)
                .BackgroundFmg(CadetBlue)
                .VerticalOptionsFmg(End)
            )
        )
        .ItemsFmg(
            new TabBar()
            .AssignFmg(out tabBar)
        );

        AddTab(typeof(OperationsPage), PageType.OperationsPage);
        AddTab(typeof(DashboardPage), PageType.DashboardPage);
        AddTab(typeof(HomePage), PageType.HomePage);
        AddTab(typeof(AccountPage), PageType.AccountPage);
        AddTab(typeof(SettingsPage), PageType.SettingsPage);
    }

    private static void AppShellLoaded(object sender, EventArgs e)
    {
        var shell = sender as AppShell;

        shell.Window.SubscribeToSafeAreaChanges(safeArea =>
        {
            shell.pageContainer.Margin = safeArea;
            shell.tabBarView.Margin = safeArea;
            shell.bottomBackgroundRectangle.IsVisible = safeArea.Bottom > 0;
            shell.bottomBackgroundRectangle.HeightRequest = safeArea.Bottom;
        });
    }

    private void AddTab(Type page, PageType pageEnum)
    {
        Tab tab = new Tab { Route = pageEnum.ToString(), Title = pageEnum.ToString() };
        tab.Items.Add(new ShellContent { ContentTemplate = new DataTemplate(page) });

        tabBar.Items.Add(tab);
    }

    private void TabBarViewCurrentPageChanged(object sender, TabBarEventArgs e)
    {
        Shell.Current.GoToAsync("///" + e.CurrentPage.ToString());
    }
}
