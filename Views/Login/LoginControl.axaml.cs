using Avalonia.Controls;
using Avalonia.Interactivity;
using CinephoriaDesktop.Services;
using CinephoriaDesktop.Views.Error;

namespace CinephoriaDesktop.Views.Login;

public partial class LoginControl : UserControl
{
    public LoginControl()
    {
        InitializeComponent();
    }
    
    private void Connect(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(PasswordTextBox.Text))
        {
            EmptyCredentialsErrorWindow errorWindow = new EmptyCredentialsErrorWindow();
            errorWindow.ShowDialog(TopLevel.GetTopLevel(this) as Window);
        }
        else
        {
            if (!AuthentificationService.Authenticate(EmailTextBox.Text, PasswordTextBox.Text))
            {
                WrongCredentialsErrorWindow wrongCredentialsErrorWindow = new WrongCredentialsErrorWindow();
                wrongCredentialsErrorWindow.ShowDialog(TopLevel.GetTopLevel(this) as Window);
            }
        }
        
        // TODO Display the Hall list window
    }
}