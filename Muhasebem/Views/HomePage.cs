namespace Muhasebem.Views;

public partial class HomePage(HomePageViewModel viewModel) : BasePage<HomePageViewModel>(viewModel, "Ana sayfa")
{
    public override void Build()
    {
        this
        .ContentFmg(
            new VerticalStackLayout()
            .CenterFmg()
            .ChildrenFmg(
                new Label()
                .TextFmg("ANA SAYFA")
                .FontSizeFmg(25)
                .TextColorFmg(White)
            )
        );
    }
}
