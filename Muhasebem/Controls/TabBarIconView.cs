namespace Muhasebem.Controls;

public partial class TabBarIconView : ContentView
{
    public void BuildUI()
    {
        var IconStyle = new Style<Icon>(e => e
            .HorizontalOptionsFmg(Center)
            .VerticalOptionsFmg(Center)
            .TintColorFmg(White));
        this
        .ContentFmg(
            new Icon()
            .StyleFmg(IconStyle)
            .SourceFmg(e => e.PathFmg("Source"))
        );
    }
}
