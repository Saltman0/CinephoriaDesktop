using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CinephoriaDesktop.Views.Error;

public partial class WrongCredentialsErrorWindow : Window
{
    public WrongCredentialsErrorWindow()
    {
        InitializeComponent();
    }

    private void CloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}