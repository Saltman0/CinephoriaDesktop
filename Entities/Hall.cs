using System;

namespace CinephoriaDesktop.Entities;

public class Hall
{
    private int _id;
    private int _number;
    private string _projectionQuality;
    private int _cinemaId;

    public Hall(int number, string projectionQuality, int cinemaId)
    {
        _number = number;
        _projectionQuality = projectionQuality;
        _cinemaId = cinemaId;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public int Number
    {
        get => _number;
        set => _number = value;
    }

    public string ProjectionQuality
    {
        get => _projectionQuality;
        set => _projectionQuality = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int CinemaId
    {
        get => _cinemaId;
        set => _cinemaId = value;
    }
}