using System;

namespace CinephoriaDesktop.Entities;

public class Incident
{
    private int _id;
    private string _type;
    private string _description;

    public Incident(string type, string description)
    {
        _type = type;
        _description = description;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Type
    {
        get => _type;
        set => _type = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }
}