namespace Muhasebem.Controls;

public partial class TabBarView : ContentView
{
    GraphicsView backGraphicsView;
    Grid buttonsGrid;
    public void BuildUI()
    {
        this
        .ResourcesFmg(
            new ResourceDictionary
            {
                new Style<TabBarIconView>(e => e
                .HeightRequestFmg(20)
                .WidthRequestFmg(30)
                .VerticalOptionsFmg(Start)
                .BackgroundFmg(Transparent)),

                new Style<ContentButton>(e => e
                .HeightRequestFmg(80)
                .FillBothDirectionsFmg()
                .MarginFmg(0)
                .BackgroundFmg(Transparent))
            }
        )
        .ContentFmg(
            new Grid()
            .VerticalOptionsFmg(Center)
            .HeightRequestFmg(80)
            .ChildrenFmg(
                new GraphicsView()
                .AssignFmg(out backGraphicsView)
                .HeightRequestFmg(80)
                .InputTransparentFmg(true)
                .BackgroundFmg(Transparent)
                .OnSizeChangedFmg(TabBarViewSizeChanged),

                new Grid()
                .VerticalOptionsFmg(End)
                .HorizontalOptionsFmg(Fill)
                .HeightRequestFmg(80)
                .AssignFmg(out buttonsGrid)
                .ColumnDefinitionsFmg(e => e.Star().Star().Star().Star().Star())
                .ChildrenFmg(
                    new ContentButton()
                    .ColumnFmg(0)
                    .SemanticDescriptionFmg("İşlemler Sayfası")
                    .InvokeOnElementFmg(e => e.Clicked += ButtonTapped)
                    .ContentFmg(
                        new TabBarIconView() { Source = "accounting.png", Page = PageType.OperationsPage }
                    ),

                    new ContentButton()
                    .ColumnFmg(1)
                    .SemanticDescriptionFmg("İstatistik Sayfası")
                    .InvokeOnElementFmg(e => e.Clicked += ButtonTapped)
                    .ContentFmg(
                        new TabBarIconView() { Source = "page.png", Page = PageType.DashboardPage }
                    ),

                    new ContentButton()
                    .ColumnFmg(2)
                    .SemanticDescriptionFmg("AnaSayfa")
                    .InvokeOnElementFmg(e => e.Clicked += ButtonTapped)
                    .ContentFmg(
                        new TabBarIconView() { Source = "home.png", Page = PageType.HomePage }
                    ),

                    new ContentButton()
                    .ColumnFmg(3)
                    .SemanticDescriptionFmg("Hesabım Sayfası")
                    .InvokeOnElementFmg(e => e.Clicked += ButtonTapped)
                    .ContentFmg(
                        new TabBarIconView() { Source = "user.png", Page = PageType.AccountPage }
                    ),

                    new ContentButton()
                    .ColumnFmg(4)
                    .SemanticDescriptionFmg("Ayarlar Sayfası")
                    .InvokeOnElementFmg(e => e.Clicked += ButtonTapped)
                    .ContentFmg(
                        new TabBarIconView() { Source = "setting.png", Page = PageType.SettingsPage }
                    )
                )
            )
        );
    }
}
