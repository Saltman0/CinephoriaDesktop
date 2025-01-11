using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CinephoriaDesktop.Factory;

public static class HttpClientFactory
{
    public static HttpClient Create(string baseAddress)
    {
        HttpClient httpClient = new HttpClient();
        
        httpClient.BaseAddress = new Uri(baseAddress);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        return httpClient;
    }
}