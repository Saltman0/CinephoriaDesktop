namespace CinephoriaDesktop.Services;

public interface IApiService
{
    string Authenticate(string email, string password);
}