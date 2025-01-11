using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CinephoriaDesktop.Factory;

namespace CinephoriaDesktop.Services;

public static class ApiService
{
    public static string Authenticate(string baseAddress, string email, string password)
    {
        Console.WriteLine("Authenticating... with "+email+" and password "+password);

        try
        {
            StringContent content = new StringContent(
                JsonSerializer.Serialize(new { email, password }), Encoding.UTF8, "application/json"
            );

            HttpResponseMessage response = HttpClientFactory.Create(baseAddress).PostAsync("/login", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "error";
        }
        
        return "error";
    }
}