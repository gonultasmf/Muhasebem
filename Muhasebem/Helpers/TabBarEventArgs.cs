namespace Muhasebem.Helpers;

public class TabBarEventArgs : EventArgs
{
    public PageType CurrentPage { get; private set; }

    public TabBarEventArgs(PageType currentPage)
    {
        CurrentPage = currentPage;
    }
}
