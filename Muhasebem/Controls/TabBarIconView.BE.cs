﻿namespace Muhasebem.Controls;

public partial class TabBarIconView
{
    public PageType Page { get; set; }

    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(TabBarIconView), default(ImageSource), BindingMode.OneWay);


    public TabBarIconView()
    {
        BuildUI();
        BindingContext = this;
    }
}