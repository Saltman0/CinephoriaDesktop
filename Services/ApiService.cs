using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CinephoriaDesktop.Services;

public class ApiService : IApiService
{
    private HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://172.18.0.6");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public string Authenticate(string email, string password)
    {
        Console.WriteLine("Authenticating... with "+email+" and password "+password);

        try
        {
            StringContent content = new StringContent(
                JsonSerializer.Serialize(new { email, password }), Encoding.UTF8, "application/json"
            );

            HttpResponseMessage response = _httpClient.PostAsync("/login", content).Result;

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