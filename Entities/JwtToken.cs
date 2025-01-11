using System;

namespace CinephoriaDesktop.Entities;

public class JwtToken
{
    private string _value;

    public JwtToken(string value)
    {
        _value = value;
    }

    public string Value
    {
        get => _value;
        set => _value = value ?? throw new ArgumentNullException(nameof(value));
    }
}