using Avalonia.Controls;
using Avalonia.Interactivity;
using CinephoriaDesktop.Views.Incident;
using CinephoriaDesktop.Views.Login;

namespace CinephoriaDesktop.Views;

public partial class HeaderControl : UserControl
{
    public HeaderControl()
    {
        InitializeComponent();
    }
    
    private void ReportIncident(object? sender, RoutedEventArgs e)
    {
        var window = TopLevel.GetTopLevel(this) as Window;
        if (window != null) new IncidentReportWindow().ShowDialog(window);
    }

    private void Disconnect(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this) as Window;
        if (topLevel != null) topLevel.Content = new LoginControl();
    }
}