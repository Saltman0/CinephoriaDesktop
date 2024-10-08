using Avalonia.Controls;
using Avalonia.Interactivity;
using CinephoriaDesktop.Views.Login;

namespace CinephoriaDesktop.Views;

public partial class HeaderControl : UserControl
{
    public HeaderControl()
    {
        InitializeComponent();
    }

    private void Disconnect(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel != null) topLevel.Content = new LoginControl();
    }
}