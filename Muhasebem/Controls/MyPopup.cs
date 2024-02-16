namespace Muhasebem.Controls;

public partial class MyPopup : Popup
{
    public MyPopup(PopupType pType = PopupType.Info, string title = "Bilgi", string description = "", string okBtnTxt = "OK", string cancelBtnTxt = "İPTAL")
    {
        var iconFile = pType == PopupType.Info ? "info" : pType == PopupType.Warning ? "warning" : "error";
        this
        .CanBeDismissedByTappingOutsideOfPopupFmg(pType != PopupType.Warning)
        .ColorFmg(Transparent)
        .ContentFmg(
            new Grid()
            .WidthRequestFmg(250)
            .HeightRequestFmg(175)
            .ChildrenFmg(
                new Frame()
                .CornerRadiusFmg(25)
                .BackgroundColorFmg(DarkGray)
                .BorderColorFmg(DarkGray)
                .FillBothDirectionsFmg()
                .ContentFmg(
                    new Grid()
                    .ColumnDefinitionsFmg(e => e.Star(3).Star(7))
                    .RowDefinitionsFmg(e => e.Star(2).Star(6).Star(2))
                    .RowSpanFmg(10)
                    .FillBothDirectionsFmg()
                    .MarginFmg(10)
                    .PaddingFmg(0)
                    .ChildrenFmg(
                        new Label()
                        .TextFmg(title)
                        .FontAttributesFmg(Bold)
                        .FontSizeFmg(18)
                        .TextColorFmg(White)
                        .CenterFmg()
                        .RowFmg(0)
                        .ColumnFmg(1),

                        new Label()
                        .TextFmg(description)
                        .FontAttributesFmg(Italic)
                        .FontSizeFmg(14)
                        .TextColorFmg(White)
                        .CenterFmg()
                        .RowFmg(1)
                        .ColumnFmg(1),

                        new SKLottieView()
                        .SourceFmg(new SKFileLottieImageSource().FileFmg($"{iconFile}.json"))
                        .RepeatCountFmg(1)
                        .HeightRequestFmg(75)
                        .WidthRequestFmg(75)
                        .ColumnFmg(0)
                        .RowFmg(0)
                        .RowSpanFmg(3)
                        .CenterFmg(),

                        new HorizontalStackLayout()
                        .ColumnSpanFmg(2)
                        .RowFmg(2)
                        .SpacingFmg(10)
                        .FillHorizontalFmg()
                        .ChildrenFmg(
                            new Button()
                            .TextFmg(cancelBtnTxt)
                            .FontAttributesFmg(Bold)
                            .FontSizeFmg(15)
                            .WidthRequestFmg(100)
                            .IsVisibleFmg(pType == PopupType.Warning)
                            .BackgroundColorFmg(CadetBlue)
                            .OnClickedFmg(async (sender, e) =>
                            {
                                await CloseAsync();
                            }),

                            new Button()
                            .TextFmg(okBtnTxt)
                            .FontAttributesFmg(Bold)
                            .FontSizeFmg(15)
                            .WidthRequestFmg(100)
                            .HeightRequestFmg(25)
                            .BackgroundColorFmg(CadetBlue)
                            .AlignEndFmg()
                            .PaddingFmg(0)
                            .OnClickedFmg(async (sender, e) =>
                            {
                                await CloseAsync();
                            })
                        )


                        

                    )
                )
            )
        );
    }
}
