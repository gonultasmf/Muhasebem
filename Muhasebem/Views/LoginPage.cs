using Microsoft.Maui.Controls.Shapes;

namespace Muhasebem.Views;

public partial class LoginPage(LoginPageViewModel viewModel) : BasePage<LoginPageViewModel>(viewModel, "Giriş Sayfası")
{
    bool isCheckLogin = false;
    public override async void Build()
    {
        isCheckLogin = await CheckLogin();
        this
        .ShellNavBarIsVisibleFmg(false)
        .BackgroundColorFmg(Black)
        .OnLoadedFmg((sender, e) =>
        {
            if (isCheckLogin)
                Application.Current.MainPage = new AppShell();
                //await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        })
        .ContentFmg(
            new Grid()
            .RowDefinitionsFmg(e => e.Star(3).Star(4).Star(3))
            .FillBothDirectionsFmg()
            .ChildrenFmg(
                new ActivityIndicator()
                .IsRunningFmg(isCheckLogin)
                .IsVisibleFmg(isCheckLogin)
                .RowSpanFmg(3)
                .CenterFmg()
                .SizeRequestFmg(75, 75),

                new SKLottieView()
                .SourceFmg(new SKFileLottieImageSource().FileFmg("iconapp.json"))
                .RepeatCountFmg(-1)
                .HeightRequestFmg(250)
                .WidthRequestFmg(250)
                .IsVisibleFmg(!isCheckLogin),

                new Border()
                .StrokeShapeFmg(new RoundRectangle().CornerRadiusFmg(new CornerRadius(35,35,35,35)))
                .StrokeThicknessFmg(2)
                .BackgroundColorFmg(Transparent)
                .PaddingFmg(new Thickness(20,5))
                .MarginFmg(20)
                .RowFmg(1)
                .IsVisibleFmg(!isCheckLogin)
                .ContentFmg(
                    new VerticalStackLayout()
                    .AlignStartFmg()
                    .FillHorizontalFmg()
                    .PaddingFmg(new Thickness(0,40,0,0))
                    .SpacingFmg(10)
                    .ChildrenFmg(
                        new TextField()
                        .TitleFmg("Mail")
                        .TitleColorFmg(LightGray)
                        .AccentColorFmg(CadetBlue)
                        .TextColorFmg(White)
                        .TextFmg(e => e.PathFmg("LoginModel.Username")),

                        new TextField()
                        .TitleFmg("Password")
                        .TitleColorFmg(LightGray)
                        .AccentColorFmg(CadetBlue)
                        .TextColorFmg(White)
                        .IsPasswordFmg(true)
                        .TextFmg(e => e.PathFmg("LoginModel.Password")),

                        new Uranium.CheckBox()
                        .BorderColorFmg(LightGray)
                        .ColorFmg(CadetBlue)
                        .TextFmg("Beni Hatırla")
                        .TextColorFmg(White)
                        .IsCheckedFmg(e => e.PathFmg("LoginModel.IsRememberMe")),

                        new Button()
                        .TextFmg("GİRİŞ YAP")
                        .FontAttributesFmg(Bold)
                        .FontSizeFmg(17)
                        .WidthRequestFmg(200)
                        .BackgroundColorFmg(CadetBlue)
                        .CommandFmg(BindingContext.LoginCommand)
                    )
                )
            )
        );
    }

    private async Task<bool> CheckLogin()
    {
        var auth = await SecureStorage.GetAsync("USERAUTH");

        if(string.IsNullOrEmpty(auth))
            return false;

        var info = AuthCheckHelper.ParseBasicAuthToken(auth);
        if(info.Item3.Value.Date < DateTime.Now.Date)
        {
            SecureStorage.Remove("USERAUTH");

            return false;
        }

        return true;
    }
}
