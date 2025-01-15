using System;

namespace CinephoriaDesktop.Entities;

public class Incident
{
    private int _id;
    private string _type;
    private string _description;
    private int _hallId;

    public Incident(string type, string description, int hallId)
    {
        _type = type;
        _description = description;
        _hallId = hallId;
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

    public int HallId
    {
        get => _hallId;
        set => _hallId = value;
    }
}