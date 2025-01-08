using System;

namespace CinephoriaDesktop.Entities;

public class Incident
{
    private string value;

    public Incident(string value)
    {
        this.value = value;
    }

    public string Value
    {
        get => value;
        set => this.value = value ?? throw new ArgumentNullException(nameof(value));
    }
}