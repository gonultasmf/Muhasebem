namespace Muhasebem.Views;

public partial class OperationsPage(OperationsPageViewModel viewModel) : BasePage<OperationsPageViewModel>(viewModel, "İşlemler Sayfası")
{
    public override void Build()
    {
        this
        .ContentFmg(
            new VerticalStackLayout()
            .CenterFmg()
            .ChildrenFmg(
                new Label()
                .TextFmg("İŞLEMLER")
                .FontSizeFmg(25)
                .TextColorFmg(White)
            )
        );
    }
}
