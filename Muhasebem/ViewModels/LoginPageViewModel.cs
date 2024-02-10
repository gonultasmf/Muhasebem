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
            await Shell.Current.ShowPopupAsync(new MyPopup());
        }
        else
        {
            // Ana sayfaya git
        }
    });
}
