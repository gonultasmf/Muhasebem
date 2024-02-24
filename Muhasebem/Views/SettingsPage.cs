namespace Muhasebem.Views;

public partial class SettingsPage(SettingsPageViewModel viewModel) : BasePage<SettingsPageViewModel>(viewModel, "Ayarlar")
{
    public override void Build()
    {
        this
        .ContentFmg(
            new VerticalStackLayout()
            .CenterFmg()
            .ChildrenFmg(
                new Label()
                .TextFmg("AYARLAR")
                .FontSizeFmg(25)
                .TextColorFmg(White)
            )
        );
    }
}
