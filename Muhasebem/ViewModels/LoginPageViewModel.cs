using System.Windows.Input;

namespace Muhasebem.ViewModels;

public partial class LoginPageViewModel(IUserRepository repository) : BaseViewModel
{
    [ObservableProperty]
    private LoginDTO loginModel = new();

    public ICommand LoginCommand => new Command(async () =>
    {
        if (LoginModel == default!)
            return;

        var result = repository.Get(x => x.Email == LoginModel.Username && x.Password == LoginModel.Password);

        if (result is null)
        {
            await Application.Current.MainPage.ShowPopupAsync(new MyPopup(PopupType.Error, "HATA", "Mail veya Şifre Yanlış Girildi."));
        }
        else
        {
            if (LoginModel.IsRememberMe)
            {
                var expireTime = DateTime.Now.AddDays(14);
                var auth = AuthCheckHelper.BasicAuth(result.Email, result.Password, expireTime);
                await SecureStorage.SetAsync("USERAUTH", auth);
            }

            Application.Current.MainPage = new AppShell();
        }
    });
}
