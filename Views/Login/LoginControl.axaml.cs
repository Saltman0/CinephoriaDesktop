using System;
using System.Collections.Generic;
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
            JwtToken? jwtToken = ApiService.Authenticate(EmailTextBox.Text, PasswordTextBox.Text);

            if (jwtToken == null)
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

                    GetDatas(cinephoriaDesktopDatabase, jwtToken.Value);
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

    private void GetDatas(LiteDatabase cinephoriaDesktopDatabase, string jwtToken)
    {
        ILiteCollection<JwtToken> jwtTokenCollection = cinephoriaDesktopDatabase.GetCollection<JwtToken>("jwtTokens");
        jwtTokenCollection.Insert(JwtTokenFactory.Create(jwtToken));

        ILiteCollection<Cinema> userCollection = cinephoriaDesktopDatabase.GetCollection<Cinema>("users");
        var user = ApiService.GetUser(jwtToken);
        Console.WriteLine(user);

        ILiteCollection<Movie> movieCollection = cinephoriaDesktopDatabase.GetCollection<Movie>("movies");
        List<Movie> movies = ApiService.GetMovies(jwtToken);
        foreach (Movie movie in movies)
        {
            Console.WriteLine("Title : " + movie.Title);
            Console.WriteLine("Description : " + movie.Description);
            Console.WriteLine("Minimum age : " + movie.MinimumAge);
            Console.WriteLine("Favorite : " + movie.Favorite);
            Console.WriteLine("Image URL : " + movie.ImageUrl);
            Console.WriteLine("Category ID : " + movie.CategoryId);
        }

        ILiteCollection<Showtime> showtimeCollection = cinephoriaDesktopDatabase.GetCollection<Showtime>("showtimes");
        foreach (Showtime showtime in ApiService.GetShowtimes(jwtToken))
        {
            Console.WriteLine("Price : " + showtime.Price);
            Console.WriteLine("Start Time : " + showtime.StartTime);
            Console.WriteLine("End Time : " + showtime.EndTime);
            Console.WriteLine("Movie ID : " + showtime.MovieId);
            Console.WriteLine("Hall ID : " + showtime.HallId);
        }

        ILiteCollection<Cinema> cinemaCollection = cinephoriaDesktopDatabase.GetCollection<Cinema>("cinemas");
        foreach (Cinema cinema in ApiService.GetCinemas(jwtToken))
        {
            Console.WriteLine("Name : " + cinema.Name);
            Console.WriteLine("Address : " + cinema.Address);
            Console.WriteLine("Postal code : " + cinema.PostalCode);
            Console.WriteLine("City : " + cinema.City);
            Console.WriteLine("Phone number : " + cinema.PhoneNumber);
            Console.WriteLine("Open hour : " + cinema.OpenHour);
            Console.WriteLine("Close hour : " + cinema.CloseHour);
        }

        ILiteCollection<Entities.Hall> hallCollection = cinephoriaDesktopDatabase.GetCollection<Entities.Hall>("halls");
        foreach (Entities.Hall hall in ApiService.GetHalls(jwtToken, 1))
        {
            Console.WriteLine("Number : " + hall.Number);
            Console.WriteLine("Projection quality : " + hall.ProjectionQuality);
            Console.WriteLine("Cinema ID : " + hall.CinemaId);
        }

        ILiteCollection<Entities.Incident> incidentCollection =
            cinephoriaDesktopDatabase.GetCollection<Entities.Incident>("incidents");
        foreach (Entities.Incident incident in ApiService.GetIncidents(jwtToken, 1))
        {
            Console.WriteLine("Type : " + incident.Type);
            Console.WriteLine("Description : " + incident.Description);
        }
    }
}