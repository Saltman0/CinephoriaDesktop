using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class HallFactory
{
    public static Hall Create(int number, string projectionQuality, int cinemaId)
    {
        return new Hall(number, projectionQuality, cinemaId);
    }
}