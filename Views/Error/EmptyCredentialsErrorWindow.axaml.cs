using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CinephoriaDesktop.Views.Error;

public partial class EmptyCredentialsErrorWindow : Window
{
    public EmptyCredentialsErrorWindow()
    {
        InitializeComponent();
    }

    private void CloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}