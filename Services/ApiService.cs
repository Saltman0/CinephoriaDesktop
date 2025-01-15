using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using CinephoriaDesktop.Factory;
using System.IdentityModel.Tokens.Jwt;
using CinephoriaDesktop.Entities;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CinephoriaDesktop.Services;

public static class ApiService
{
    private static readonly string BaseAddress = "http://172.18.0.6";
    
    public static JwtToken? Authenticate(string email, string password)
    {
        Console.WriteLine("Authenticating... with "+email+" and password "+password);

        try
        {
            StringContent content = new StringContent(
                JsonSerializer.Serialize(new { email, password }), Encoding.UTF8, "application/json"
            );

            HttpResponseMessage response = HttpClientFactory.Create(BaseAddress, null).PostAsync("/login", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<JwtToken>(response.Content.ReadAsStringAsync().Result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
        return null;
    }

    public static User? GetUser(string jwtToken)
    {
        Console.WriteLine("Getting user with "+jwtToken);

        try
        {
            // We need to decode the JWT Token to get the user ID inside it for requesting the user database
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            Console.WriteLine(handler.CanReadToken(jwtToken));
            if (handler.CanReadToken(jwtToken))
            {
                JwtSecurityToken decodedJwtToken = handler.ReadJwtToken(jwtToken);

                int? userId = null;
                foreach (Claim claim in decodedJwtToken.Claims)
                {
                    Console.WriteLine("Type : "+claim.Type+" Value : "+claim.Value);
                    if (claim.Type == "id")
                    {
                        userId = int.Parse(claim.Value);
                        break;
                    }
                }

                HttpResponseMessage response = HttpClientFactory.Create(BaseAddress, null).GetAsync("/user"+userId).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<User>(jsonString);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
        return null;
    }

    public static List<Movie>? GetMovies(string jwtToken)
    {
        Console.WriteLine("Getting movies");

        try
        {
            HttpResponseMessage response = HttpClientFactory.Create(BaseAddress, jwtToken).GetAsync("/movie").Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Movie>>(jsonString);
            }

            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public static List<Showtime>? GetShowtimes(string jwtToken)
    {
        Console.WriteLine("Getting showtimes");

        try
        {
            HttpResponseMessage response = HttpClientFactory.Create(BaseAddress, jwtToken).GetAsync("/showtime").Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Showtime>>(jsonString);
            }

            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public static List<Cinema>? GetCinemas(string jwtToken)
    {
        Console.WriteLine("Getting cinemas");

        try
        {
            HttpResponseMessage response = HttpClientFactory.Create(BaseAddress, jwtToken).GetAsync("/cinema").Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Cinema>>(jsonString);
            }

            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public static List<Hall>? GetHalls(string jwtToken, int cinemaId)
    {
        Console.WriteLine("Getting halls");

        try
        {
            HttpResponseMessage response = HttpClientFactory.Create(BaseAddress, jwtToken).GetAsync("cinema/"+cinemaId+"/hall").Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Hall>>(jsonString);
            }

            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public static List<Incident>? GetIncidents(string jwtToken, int hallId)
    {
        Console.WriteLine("Getting incidents");

        try
        {
            HttpResponseMessage response = HttpClientFactory.Create(BaseAddress, jwtToken).GetAsync("hall/"+hallId+"/incident").Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Incident>>(jsonString);
            }

            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}