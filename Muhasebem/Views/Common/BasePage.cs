namespace Muhasebem.Views;

public abstract class BasePage<TViewModel> : ContentPage where TViewModel : BaseViewModel
{
    protected BasePage(TViewModel viewModel, string title)
    {
        base.BindingContext = viewModel;
        Title = title;

        Build();
    }

    protected new TViewModel BindingContext => (TViewModel)base.BindingContext;

    public abstract void Build();

    protected override void OnAppearing()
    {
        base.OnAppearing();
#if DEBUG
        HotReloadHandler.UpdateApplicationEvent += ReloadUI;
#endif
    }

    private void ReloadUI(Type[]? obj)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Build();
        });
    }
}
