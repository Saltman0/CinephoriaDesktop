using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CinephoriaDesktop.Factory;

public static class HttpClientFactory
{
    public static HttpClient Create(string baseAddress, string? jwtToken)
    {
        HttpClient httpClient = new HttpClient();
        
        httpClient.BaseAddress = new Uri(baseAddress);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        if (jwtToken != null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        }
        
        return httpClient;
    }
}