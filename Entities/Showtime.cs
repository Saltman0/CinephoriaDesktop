using System;

namespace CinephoriaDesktop.Entities;

public class Showtime
{
    private DateTime _startTime;
    private DateTime _endTime;
    private int _price;
    private int _movieId;
    private int _hallId;

    public Showtime(DateTime startTime, DateTime endTime, int price, int movieId, int hallId)
    {
        _startTime = startTime;
        _endTime = endTime;
        _price = price;
        _movieId = movieId;
        _hallId = hallId;
    }

    public DateTime StartTime
    {
        get => _startTime;
        set => _startTime = value;
    }

    public DateTime EndTime
    {
        get => _endTime;
        set => _endTime = value;
    }

    public int Price
    {
        get => _price;
        set => _price = value;
    }

    public int MovieId
    {
        get => _movieId;
        set => _movieId = value;
    }

    public int HallId
    {
        get => _hallId;
        set => _hallId = value;
    }
}