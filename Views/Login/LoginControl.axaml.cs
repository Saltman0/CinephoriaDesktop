using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CinephoriaDesktop.Entities;
using CinephoriaDesktop.Factory;
using CinephoriaDesktop.Services;
using CinephoriaDesktop.Views.Error;
using CinephoriaDesktop.Views.Hall;
using LiteDB;

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
            string result = ApiService.Authenticate("http://172.18.0.6", EmailTextBox.Text, PasswordTextBox.Text);

            if (result == "error")
            {
                WrongCredentialsErrorWindow wrongCredentialsErrorWindow = new WrongCredentialsErrorWindow();
                wrongCredentialsErrorWindow.ShowDialog(TopLevel.GetTopLevel(this) as Window);
            }
            else
            {
                string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                
                string databasePath = Path.Combine(baseDirectory, "CinephoriaDesktop", "CinephoriaDesktop.db");
                
                LiteDatabase? cinephoriaDesktopDatabase = DatabaseService.GetDatabase("/home/saltman/Documents/Test/CinephoriaDesktop.db");

                if (cinephoriaDesktopDatabase != null)
                {
                    Console.WriteLine("Database created successfully.");

                    ILiteCollection<JwtToken> jwtTokenCollection = cinephoriaDesktopDatabase.GetCollection<JwtToken>("jwtTokens");
                    jwtTokenCollection.Insert(JwtTokenFactory.Create(result));
                }
                else
                {
                    WrongCredentialsErrorWindow wrongCredentialsErrorWindow = new WrongCredentialsErrorWindow();
                    wrongCredentialsErrorWindow.ShowDialog(TopLevel.GetTopLevel(this) as Window);
                }
                
                // TODO Display the Hall list control
                Content = new HallListControl();
            }
        }
    }
}