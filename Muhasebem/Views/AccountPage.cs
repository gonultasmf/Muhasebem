namespace Muhasebem.Views;

public partial class AccountPage(AccountPageViewModel viewModel) : BasePage<AccountPageViewModel>(viewModel, "Hesabım")
{
    public override void Build()
    {
        this
        .ContentFmg(
            new VerticalStackLayout()
            .CenterFmg()
            .ChildrenFmg(
                new Label()
                .TextFmg("AccountPage")
                .FontSizeFmg(25)
                .TextColorFmg(White)
            )
        );
    }
}
