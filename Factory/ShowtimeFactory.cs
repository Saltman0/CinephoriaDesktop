using System;
using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class ShowtimeFactory
{
    public static Showtime Create(DateTime _startTime, DateTime _endTime, int price, int movieId, int hallId)
    {
        return new Showtime(_startTime, _endTime, price, movieId, hallId);
    }
}