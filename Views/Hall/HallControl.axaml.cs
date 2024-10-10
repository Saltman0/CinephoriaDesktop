using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CinephoriaDesktop.Views.Incident;

namespace CinephoriaDesktop.Views.Hall;

public partial class HallControl : UserControl
{
    public HallControl()
    {
        InitializeComponent();
    }
    
    private void DisplayIncidents(object? sender, RoutedEventArgs e)
    {
        // TODO Display the Incident list window
        Console.WriteLine("DisplayIncidents");
        var window = TopLevel.GetTopLevel(this) as Window;
        if (window != null) new IncidentListWindow().ShowDialog(window);
    }
}