using System;
using Avalonia.Controls;
using CinephoriaDesktop.Services;
using CinephoriaDesktop.Views.Login;

namespace CinephoriaDesktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ShowLoginView();
        Closed += MainWindowClosed;
    }
    
    private void ShowLoginView()
    {
        Content = new LoginControl();
    }

    public void MainWindowClosed(object? sender, EventArgs e)
    {
        Console.WriteLine("MainWindow Closed");

        bool isDatabaseDeleted = DatabaseService.DeleteDatabase("/home/saltman/Documents/Test/CinephoriaDesktop.db");

        Console.WriteLine(isDatabaseDeleted ? "Database deleted." : "Database not deleted.");
    }
}