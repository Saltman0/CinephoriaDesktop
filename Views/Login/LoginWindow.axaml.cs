using Avalonia.Controls;
using Avalonia.Interactivity;
using CinephoriaDesktop.Services;
using CinephoriaDesktop.Views.Error;

namespace CinephoriaDesktop.Views.Login;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }
    
    private void Connect(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(PasswordTextBox.Text))
        {
            EmptyCredentialsErrorWindow errorWindow = new EmptyCredentialsErrorWindow();
            errorWindow.ShowDialog(this);
        }
        else
        {
            if (!AuthentificationService.Authenticate(EmailTextBox.Text, PasswordTextBox.Text))
            {
                WrongCredentialsErrorWindow wrongCredentialsErrorWindow = new WrongCredentialsErrorWindow();
                wrongCredentialsErrorWindow.ShowDialog(this);
            }
        }
        
        // TODO Display the Hall list window
    }
}