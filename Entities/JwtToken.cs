using System;

namespace CinephoriaDesktop.Entities;

public class JwtToken
{
    private string value;

    public JwtToken(string value)
    {
        this.value = value;
    }

    public string Value
    {
        get => value;
        set => this.value = value ?? throw new ArgumentNullException(nameof(value));
    }
}