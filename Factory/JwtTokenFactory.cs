using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class JwtTokenFactory
{
    public static JwtToken CreateJwtToken(string value)
    {
        return new JwtToken(value);
    }
}