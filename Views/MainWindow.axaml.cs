using Avalonia.Controls;
using CinephoriaDesktop.Views.Login;

namespace CinephoriaDesktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ShowLoginView();
    }

    private void ShowLoginView()
    {
        Content = new LoginControl();
    }
}