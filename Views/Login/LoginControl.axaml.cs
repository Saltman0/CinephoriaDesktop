using System;
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
    private readonly IApiService _apiService;
    
    public LoginControl(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
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
            string result = _apiService.Authenticate(EmailTextBox.Text, PasswordTextBox.Text);

            if (result == "error")
            {
                WrongCredentialsErrorWindow wrongCredentialsErrorWindow = new WrongCredentialsErrorWindow();
                wrongCredentialsErrorWindow.ShowDialog(TopLevel.GetTopLevel(this) as Window);
            }
            
            using (LiteDatabase database = new LiteDatabase(@"CinephoriaDesktop.db"))
            {
                ILiteCollection<JwtToken> jwtTokenCollection = database.GetCollection<JwtToken>("jwtTokens");
                jwtTokenCollection.Insert(JwtTokenFactory.CreateJwtToken(result));
                ILiteCollection<JwtToken> incidentTokenCollection = database.GetCollection<JwtToken>("incidents");
            }
        }
        
        // TODO Display the Hall list window
        Content = new HallListControl();
    }
}