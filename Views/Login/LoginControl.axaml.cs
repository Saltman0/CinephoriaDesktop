using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CinephoriaDesktop.Services;

namespace CinephoriaDesktop.Views.Login;

public partial class LoginControl : UserControl
{
    public LoginControl()
    {
        InitializeComponent();
    }
    
    private void Connect(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("Connect");
        
        AuthentificationService.Authenticate(EmailTextBox.Text, PasswordTextBox.Text);
        
        // TODO Envoyer une requête d'authentification vers le serveur d'authentification.
        
        // TODO Si l'authentification est un succès, rediriger vers la fenêtre des salles du cinéma.
        
        // TODO Sinon, retourner une erreur 403 et afficher un message sur la fenêtre d'authentification.
    }
}