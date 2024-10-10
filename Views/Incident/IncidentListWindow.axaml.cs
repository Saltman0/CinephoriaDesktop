using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CinephoriaDesktop.Views.Incident;

public partial class IncidentListWindow : Window
{
    public IncidentListWindow()
    {
        InitializeComponent();
    }

    private void CloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}