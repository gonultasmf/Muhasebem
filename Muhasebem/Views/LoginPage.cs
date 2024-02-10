namespace Muhasebem.Views;

public partial class LoginPage(LoginPageViewModel viewModel) : BasePage<LoginPageViewModel>(viewModel, "Giriş Sayfası")
{
    public override void Build()
    {
        this
        .ContentFmg(
            new VerticalStackLayout()
            .CenterFmg()
            .PaddingFmg(10)
            .SpacingFmg(10)
            .ChildrenFmg(
                new TextField()
                .TitleFmg("Mail")
                .TextFmg(e => e.PathFmg("LoginModel.Username")),

                new TextField()
                .TitleFmg("Password")
                .IsPasswordFmg(true)
                .TextFmg(e => e.PathFmg("LoginModel.Password")),

                new Button()
                .TextFmg("GİRİŞ YAP")
                .CommandFmg(BindingContext.LoginCommand)
            )
        );

    }
}
