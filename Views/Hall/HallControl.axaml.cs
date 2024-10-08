using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

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
    }
}