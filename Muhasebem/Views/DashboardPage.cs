namespace Muhasebem.Views;

public partial class DashboardPage(DashboardPageViewModel viewModel) : BasePage<DashboardPageViewModel>(viewModel, "İstatistik")
{
    public override void Build()
    {
        this
        .ContentFmg(
            new VerticalStackLayout()
            .CenterFmg()
            .ChildrenFmg(
                new Label()
                .TextFmg("DashboardPage")
                .FontSizeFmg(25)
                .TextColorFmg(White)
            )
        );
    }
}
