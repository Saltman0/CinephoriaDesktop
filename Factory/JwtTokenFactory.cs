using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class JwtTokenFactory
{
    public static JwtToken Create(string value)
    {
        return new JwtToken(value);
    }
}