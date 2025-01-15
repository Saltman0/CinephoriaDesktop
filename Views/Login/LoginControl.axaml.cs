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

        ILiteCollection<User> userCollection = cinephoriaDesktopDatabase.GetCollection<User>("users");
        User user = ApiService.GetUser(jwtToken);
        if (user != null)
        {
            userCollection.Insert(user);
            Console.WriteLine(user);
        }

        ILiteCollection<Movie> movieCollection = cinephoriaDesktopDatabase.GetCollection<Movie>("movies");
        List<Movie> movies = ApiService.GetMovies(jwtToken);
        if (movies != null && movies.Count > 0)
        {
            foreach (Movie movie in movies)
            {
                movieCollection.Insert(movie);
            }
        }
        
        /*ILiteCollection<Showtime> showtimeCollection = cinephoriaDesktopDatabase.GetCollection<Showtime>("showtimes");
        foreach (Showtime showtime in ApiService.GetShowtimes(jwtToken))
        {
            Console.WriteLine("Price : " + showtime.Price);
            Console.WriteLine("Start Time : " + showtime.StartTime);
            Console.WriteLine("End Time : " + showtime.EndTime);
            Console.WriteLine("Movie ID : " + showtime.MovieId);
            Console.WriteLine("Hall ID : " + showtime.HallId);
            showtimeCollection.Insert(showtime);
        }*/
        
        ILiteCollection<Cinema> cinemaCollection = cinephoriaDesktopDatabase.GetCollection<Cinema>("cinemas");
        ILiteCollection<Entities.Hall> hallCollection = cinephoriaDesktopDatabase.GetCollection<Entities.Hall>("halls");
        ILiteCollection<Entities.Incident> incidentCollection = cinephoriaDesktopDatabase.GetCollection<Entities.Incident>("incidents");
        
        List<Cinema> cinemas = ApiService.GetCinemas(jwtToken);
        if (cinemas != null && cinemas.Count > 0)
        {
            foreach (Cinema cinema in cinemas)
            {
                cinemaCollection.Insert(cinema);
                List<Entities.Hall> halls = ApiService.GetHalls(jwtToken, cinema.Id);
                if (halls != null && halls.Count > 0)
                {
                    foreach (Entities.Hall hall in halls)
                    {
                        hallCollection.Insert(hall);
                        List<Entities.Incident> incidents = ApiService.GetIncidents(jwtToken, hall.Id);
                        if (incidents != null && incidents.Count > 0)
                        {
                            foreach (Entities.Incident incident in incidents)
                            {
                                incidentCollection.Insert(incident);
                            } 
                        }
                    }
                }
            }
        }
        
    }
}